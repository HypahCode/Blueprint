using System;
using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using System.Windows.Forms;
using Blueprint.Plugins;
using Blueprint.Plugins.ImportExport;
using Blueprint.Plugins.Operations;
using Blueprint.RenderEngine;
using Blueprint.RenderEngine.RenderTargets;
using Blueprint.VectorImagess;
using BlueprintAddon;
using TrigonometryLib.Primitives;

namespace Blueprint
{
    public partial class MainForm : Form, IVectorImageProvider
    {
        private class ComboboxLayer
        {
            public VectorImage image;
            public ComboboxLayer(VectorImage img) { image = img; }
            public override string ToString()
            {
                return image.Name;
            }
        }

        public enum EditAction
        {
            ActionMovePoints = 0,
            ActionAddPoints = 1,
            ActionAddLines = 2,
        }
        private EditAction editAction = EditAction.ActionMovePoints;

        private FlickerFreePanel renderPanel;
        private LayeredVectorImage layeredVectorImage;
        private MultiSelection selection = new MultiSelection();

        private Renderer renderer = new Renderer();
        private RenderContext renderContext = new RenderContext();
        private BackgroundRenderer backgroundRenderer = new BackgroundRenderer();
        private PrimitiveRenderer primitiveRenderer = new PrimitiveRenderer();
        private ScientificRenderer scientificRenderer = new ScientificRenderer();
        private LabelOverlayRenderer labelOverlayRenderer = new LabelOverlayRenderer();

        private bool dragMouseLock = false;
        private Point dragLocation;
        private bool multiselect = false;
        private bool mouseWasMovedAfterClick = false;
        private Vector2D lineStartPoint = null;
        private object linkObject = null;

		private PluginMenuProxy operationsProxy;


        public MainForm()
        {
			operationsProxy = new PluginMenuProxy(this);

            InitializeComponent();


            renderPanel = new FlickerFreePanel();
            renderPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            renderPanel.Name = "panel";
            renderPanel.TabIndex = 1;
            renderPanel.MouseMove += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseMove);
            renderPanel.MouseDown += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseDown);
            renderPanel.MouseUp += new System.Windows.Forms.MouseEventHandler(this.panel1_MouseUp);
            renderPanel.KeyUp += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyUp);
            renderPanel.KeyDown += new System.Windows.Forms.KeyEventHandler(this.MainForm_KeyDown);
            renderPanel.OnRender += new FlickerFreePanel.RenderEventHandler(panel_Render);
            renderPanel.MouseWheel += new MouseEventHandler(panel_MouseWheel);
            mainPanel.Controls.Add(renderPanel);

            renderer.renderStack.Add(backgroundRenderer);
            renderer.renderStack.Add(primitiveRenderer);
            renderer.renderStack.Add(scientificRenderer);
            renderer.renderStack.Add(labelOverlayRenderer);
            renderContext.Location = new Vector2D(renderPanel.Width / 2, renderPanel.Height / 2);

            SetStyle(ControlStyles.UserPaint | ControlStyles.AllPaintingInWmPaint | ControlStyles.OptimizedDoubleBuffer, true);

            SetupUI();
            UpdateGUI();
        }

        public VectorImage CurrImage { get { return layeredVectorImage.Image; } }
		public LayeredVectorImage LayeredVectorImage { get { return layeredVectorImage; } }

        private void panel_MouseWheel(object sender, MouseEventArgs e)
        {
            Vector2D mouseLocation = new Vector2D(e.X, e.Y);

            Vector2D pointerPos = new Vector2D(e.X, e.Y);
            Vector2D zoomPoint = (pointerPos - renderContext.Location) / renderContext.DrawScale;

            double zoomDirection = e.Delta > 1 ? 1.0 : -1.0;
            double zoomDelta = (renderContext.DrawScale * 0.1) * zoomDirection;
            renderContext.DrawScale += zoomDelta;
            renderContext.Location -= zoomPoint * zoomDelta;
            toolStripZoomTextBox.Text = (renderContext.DrawScale * 100.0).ToString() + " %";

            UpdateGUI();
        }

        private void panel1_MouseUp(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right) dragMouseLock = false;
            if ((!mouseWasMovedAfterClick) && (!multiselect))
                selection.Clear();
        }

        private void panel1_MouseMove(object sender, MouseEventArgs e)
        {
            Point dragDelta = new Point(e.X - dragLocation.X, e.Y - dragLocation.Y);
            Vector2D dragDeltaF = new Vector2D((e.X - dragLocation.X), (e.Y - dragLocation.Y));

            mouseWasMovedAfterClick = true;

            if (dragMouseLock)
            {
                renderContext.Location.x += dragDeltaF.x;
                renderContext.Location.y += dragDeltaF.y;
            }

            if (e.Button == MouseButtons.Left)
            {
                VectorImage vecImg = layeredVectorImage.Image;
                selection.Move(dragDeltaF / renderContext.DrawScale);
            }
            dragLocation = new Point(e.X, e.Y);
            renderPanel.Render();
        }

        private void panel1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Right)
            {
                dragLocation = new Point(e.X, e.Y);
                dragMouseLock = true;
            }
            if (e.Button == MouseButtons.Left)
            {
                Vector2D loc = renderContext.ScreenToPoint(e.X, e.Y);
                Vector2D snappedLoc = loc;
                if (snapToGridPermanentButton.Checked)
                {
                    snappedLoc = renderContext.GridSnap(loc);
                }

                switch (editAction)
                {
                    case EditAction.ActionMovePoints:
                        {
                            List<Primitive2D> prims = CurrImage.GetPrimitivesAtLocation(loc, 4.0f / renderContext.DrawScale);

                            if (prims.Count == 0)
                            {
                                if (!multiselect)
                                    mouseWasMovedAfterClick = false;
                            }
                            else
                            {
                                mouseWasMovedAfterClick = true;
                                if (!multiselect)
                                {
                                    selection.Clear();
                                    selection.Add(prims[0]);
                                }
                                else
                                {
                                    selection.TogglePrimitive(prims[0]);
                                }
                            }
                            break;
                        }
                    case EditAction.ActionAddPoints:
                        {
                            CurrImage.primitives.Add(new Vector2D(snappedLoc));
                            break;
                        }
                    case EditAction.ActionAddLines:
                        {
                            if (linkObject != null)
                            {
                                ObjectLinker.EndLinkingObjects(CurrImage.GetLinkablePrimitives(), loc, linkObject);
                                linkObject = null;
                                renderPanel.Render();
                                return;
                            }
                            else
                            {
                                linkObject = ObjectLinker.StartLinkingObjects(CurrImage.GetLinkablePrimitives(), loc);
                                if (linkObject != null)
                                {
                                    renderPanel.Render();
                                    return;
                                }
                            }



                            VectorCloud2D dots = CurrImage.GetPointsAtLoction(loc, 4.0f / renderContext.DrawScale);
                            Vector2D dot;
                            if (dots.Count == 0)
                            {
                                dot = new Vector2D(snappedLoc);
                                CurrImage.primitives.Add(dot);
                            }
                            else
                            {
                                dot = dots[0];
                            }

                            if (lineStartPoint != null)
                            {
                                // Line is ready, connect!
                                CurrImage.primitives.Add(new Line2D(lineStartPoint, dot));
                                lineStartPoint = null;
                            }
                            else
                            {
                                // First dot, draw dummy line
                                lineStartPoint = dot;
                            }
                            break;
                        }
                }
            }
            renderPanel.Render();
        }

        private void MainForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Shift) multiselect = true;
            if (e.KeyCode == Keys.Delete)
            {
                lineStartPoint = null;
                linkObject = null;
                selection.RemoveFromImage(CurrImage);
            }
            renderPanel.Render();
        }

        private void MainForm_KeyUp(object sender, KeyEventArgs e)
        {
            if (!e.Shift) multiselect = false;
        }

        private void panel_Render(object sender, Graphics graphics)
        {
            renderContext.Panel = (UserControl)sender;
            renderContext.Graphics = new ScreenRenderer(graphics);
            renderer.DrawStack(renderContext);
        }

        private void SetupUI()
        {
			MenuExtender actionExtender = new MenuExtender(actionsToolStripMenuItem, operationsProxy, typeof(OperationsBase));
			actionExtender.LoadOperationsFromAssembly(Assembly.GetExecutingAssembly());
            
			MenuExtender importExtender = new MenuExtender(fileToolStripMenuItem, operationsProxy, typeof(ImportExtensionBase));
			importExtender.LoadOperationsFromAssembly(Assembly.GetExecutingAssembly());
            /*
			MenuExtender exportExtender = new MenuExtender(fileToolStripMenuItem, operationsProxy);
			importExtender.LoadOperationsFromAssembly(Assembly.GetExecutingAssembly());
				*/

            NewVectorImage();
            SetEditAction(EditAction.ActionMovePoints);
            /*
            string[] args = Environment.GetCommandLineArgs();
            if (args.Length > 1)
            {
                for (int i = 1; i < args.Length; i++)
                {
                    if (args[i].ToLower().EndsWith("wkt"))
                    {
                        WktReader.ReadFile(layeredVectorImage, args[i], 1.0f, false);
                    }
                }
            }
            */
			//CurrImage.Add (new ImageNode ());
			//CurrImage.Add (new ImageNode ());
        }

        private void SetEditAction(EditAction action)
        {
            editAction = action;
            lineStartPoint = null;
            linkObject = null;
            selection.Clear();

            ActionMovePointsBtn.Checked = action == EditAction.ActionMovePoints;
            ActionAddPointsBtn.Checked = action == EditAction.ActionAddPoints;
            ActionAddLinesBtn.Checked = action == EditAction.ActionAddLines;
        }

        private void NewVectorImage()
        {
            selection.Clear();
            layeredVectorImage = new LayeredVectorImage();
            primitiveRenderer.layeredImage = layeredVectorImage;
            labelOverlayRenderer.layeredImage = layeredVectorImage;
            toolStripLayerComboBox.Items.Clear();
            toolStripLayerComboBox.Items.Add(new ComboboxLayer(layeredVectorImage.Image));
            UpdateGUI();
        }

        private void ActionMovePointsBtn_Click(object sender, System.EventArgs e)
        {
            SetEditAction(EditAction.ActionMovePoints);
        }

        private void ActionAddPointsBtn_Click(object sender, System.EventArgs e)
        {
            SetEditAction(EditAction.ActionAddPoints);
        }

        private void ActionAddLinesBtn_Click(object sender, System.EventArgs e)
        {
            SetEditAction(EditAction.ActionAddLines);
        }

        private void newToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            NewVectorImage();
        }

        private void solidColorToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            backgroundRenderer.Style = BackgroundRenderer.BackgroundStyle.SolidColor;
        }

        private void gridToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            backgroundRenderer.Style = BackgroundRenderer.BackgroundStyle.BlueprintGrid;
        }

        private void toolStripButton1_Click(object sender, System.EventArgs e)
        {
            VectorImage img = layeredVectorImage.AddLayer();
            layeredVectorImage.Set(img);
            toolStripLayerComboBox.Items.Add(new ComboboxLayer(img));
        }

        private void toolStripButton2_Click(object sender, System.EventArgs e)
        {
            if (toolStripLayerComboBox.SelectedIndex != -1)
            {
                VectorImage vi = ((ComboboxLayer)toolStripLayerComboBox.Items[toolStripLayerComboBox.SelectedIndex]).image;
                layeredVectorImage.RemoveLayer(vi);
                toolStripLayerComboBox.Items.RemoveAt(toolStripLayerComboBox.SelectedIndex);
                selection.Clear();
            }
            UpdateGUI();
        }

        private void toolStripLayerComboBox_SelectedIndexChanged(object sender, System.EventArgs e)
        {
            VectorImage vi = ((ComboboxLayer)toolStripLayerComboBox.Items[toolStripLayerComboBox.SelectedIndex]).image;
            layeredVectorImage.Set(vi);
            selection.Clear();
            UpdateGUI();
        }

        private void UpdateGUI()
        {
            for (int i = 0; i < toolStripLayerComboBox.Items.Count; i++)
            {
                if (((ComboboxLayer)toolStripLayerComboBox.Items[i]).image == layeredVectorImage.Image)
                {
                    toolStripLayerComboBox.SelectedIndex = i;
                    break;
                }
            }

            showHidePoints.Checked = renderContext.ShowPoints;
            showHideLines.Checked = renderContext.ShowLines;
            showHideTriangles.Checked = renderContext.ShowTriangles;
            showHidefilledtriangles.Checked = renderContext.ShowFilledTriangles;
            showHideShapes.Checked = renderContext.ShowShapes;
            showHideCircles.Checked = renderContext.ShowCircles;

            toolStripZoomTextBox.Text = (renderContext.DrawScale * 100.0f).ToString() + " %";

            renderPanel.Render();
        }

        private void ShowHideItemsClick(object sender, System.EventArgs e)
        {
            switch (((ToolStripButton)sender).Text)
            {
                case "Show points": renderContext.ShowPoints = !renderContext.ShowPoints; break;
                case "Show lines": renderContext.ShowLines = !renderContext.ShowLines; break;
                case "Show triangles": renderContext.ShowTriangles = !renderContext.ShowTriangles; break;
                case "Show filled triangles": renderContext.ShowFilledTriangles = !renderContext.ShowFilledTriangles; break;
                case "Show shapes": renderContext.ShowShapes = !renderContext.ShowShapes; break;
                case "Show circles": renderContext.ShowCircles = !renderContext.ShowCircles; break;
            }
            UpdateGUI();
        }

        private void scientificToolStripMenuItem_Click(object sender, System.EventArgs e)
        {
            scientificRenderer.IsActive = !scientificRenderer.IsActive;
        }

        private void labelOverlayToolStripMenuItem_Click(object sender, EventArgs e)
        {
            labelOverlayRenderer.IsActive = !labelOverlayRenderer.IsActive;
        }

        private void toolStripButtonZoomtoFeature_Click(object sender, EventArgs e)
        {
            Rectangle2D bb = CurrImage.BoundingBox();

            double imageSize = Math.Max(bb.Width, bb.Height);
            if (imageSize > 0.0)
            {
                double screenSize = Math.Min(renderPanel.Width, renderPanel.Height);
                renderContext.DrawScale = (screenSize / imageSize) / 1.2;
            }
            else
            {
                renderContext.DrawScale = 1.0;
            }

            Vector2D displaySize = new Vector2D((renderPanel.Width / renderContext.DrawScale), (renderPanel.Height / renderContext.DrawScale));
            Vector2D center = bb.MidPoint - (displaySize / 2.0f);

            renderContext.Location.x = -center.x * renderContext.DrawScale;
            renderContext.Location.y = -center.y * renderContext.DrawScale;

            renderPanel.Render();
        }
    }
}
