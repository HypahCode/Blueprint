namespace Blueprint
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>4
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.fileToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.newToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem2 = new System.Windows.Forms.ToolStripSeparator();
            this.backgroundToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.solidColorToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.gridToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.scientificToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.labelOverlayToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStripMenuItem1 = new System.Windows.Forms.ToolStripSeparator();
            this.actionsToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.makeShapeToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.toolStrip1 = new System.Windows.Forms.ToolStrip();
            this.ActionMovePointsBtn = new System.Windows.Forms.ToolStripButton();
            this.ActionAddPointsBtn = new System.Windows.Forms.ToolStripButton();
            this.ActionAddLinesBtn = new System.Windows.Forms.ToolStripButton();
            this.snapToGridPermanentButton = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator3 = new System.Windows.Forms.ToolStripSeparator();
            this.showHidePoints = new System.Windows.Forms.ToolStripButton();
            this.showHideLines = new System.Windows.Forms.ToolStripButton();
            this.showHideTriangles = new System.Windows.Forms.ToolStripButton();
            this.showHidefilledtriangles = new System.Windows.Forms.ToolStripButton();
            this.showHideShapes = new System.Windows.Forms.ToolStripButton();
            this.showHideCircles = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel1 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripZoomTextBox = new System.Windows.Forms.ToolStripTextBox();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripLabel2 = new System.Windows.Forms.ToolStripLabel();
            this.toolStripLayerComboBox = new System.Windows.Forms.ToolStripComboBox();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.toolStripButton2 = new System.Windows.Forms.ToolStripButton();
            this.mainPanel = new System.Windows.Forms.Panel();
            this.toolStripButtonZoomtoFeature = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator4 = new System.Windows.Forms.ToolStripSeparator();
            this.menuStrip1.SuspendLayout();
            this.toolStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.fileToolStripMenuItem,
            this.actionsToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(956, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // fileToolStripMenuItem
            // 
            this.fileToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.newToolStripMenuItem,
            this.toolStripMenuItem2,
            this.backgroundToolStripMenuItem,
            this.toolStripMenuItem1});
            this.fileToolStripMenuItem.Name = "fileToolStripMenuItem";
            this.fileToolStripMenuItem.Size = new System.Drawing.Size(37, 20);
            this.fileToolStripMenuItem.Text = "File";
            // 
            // newToolStripMenuItem
            // 
            this.newToolStripMenuItem.Name = "newToolStripMenuItem";
            this.newToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.newToolStripMenuItem.Text = "New";
            this.newToolStripMenuItem.Click += new System.EventHandler(this.newToolStripMenuItem_Click);
            // 
            // toolStripMenuItem2
            // 
            this.toolStripMenuItem2.Name = "toolStripMenuItem2";
            this.toolStripMenuItem2.Size = new System.Drawing.Size(149, 6);
            // 
            // backgroundToolStripMenuItem
            // 
            this.backgroundToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.solidColorToolStripMenuItem,
            this.gridToolStripMenuItem,
            this.scientificToolStripMenuItem,
            this.labelOverlayToolStripMenuItem});
            this.backgroundToolStripMenuItem.Name = "backgroundToolStripMenuItem";
            this.backgroundToolStripMenuItem.Size = new System.Drawing.Size(152, 22);
            this.backgroundToolStripMenuItem.Text = "Background";
            // 
            // solidColorToolStripMenuItem
            // 
            this.solidColorToolStripMenuItem.Name = "solidColorToolStripMenuItem";
            this.solidColorToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.solidColorToolStripMenuItem.Text = "Solid color";
            this.solidColorToolStripMenuItem.Click += new System.EventHandler(this.solidColorToolStripMenuItem_Click);
            // 
            // gridToolStripMenuItem
            // 
            this.gridToolStripMenuItem.Name = "gridToolStripMenuItem";
            this.gridToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.gridToolStripMenuItem.Text = "Grid";
            this.gridToolStripMenuItem.Click += new System.EventHandler(this.gridToolStripMenuItem_Click);
            // 
            // scientificToolStripMenuItem
            // 
            this.scientificToolStripMenuItem.Name = "scientificToolStripMenuItem";
            this.scientificToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.scientificToolStripMenuItem.Text = "Scientific";
            this.scientificToolStripMenuItem.Click += new System.EventHandler(this.scientificToolStripMenuItem_Click);
            // 
            // labelOverlayToolStripMenuItem
            // 
            this.labelOverlayToolStripMenuItem.Name = "labelOverlayToolStripMenuItem";
            this.labelOverlayToolStripMenuItem.Size = new System.Drawing.Size(143, 22);
            this.labelOverlayToolStripMenuItem.Text = "Label overlay";
            this.labelOverlayToolStripMenuItem.Click += new System.EventHandler(this.labelOverlayToolStripMenuItem_Click);
            // 
            // toolStripMenuItem1
            // 
            this.toolStripMenuItem1.Name = "toolStripMenuItem1";
            this.toolStripMenuItem1.Size = new System.Drawing.Size(149, 6);
            // 
            // actionsToolStripMenuItem
            // 
            this.actionsToolStripMenuItem.Name = "actionsToolStripMenuItem";
            this.actionsToolStripMenuItem.Size = new System.Drawing.Size(59, 20);
            this.actionsToolStripMenuItem.Text = "Actions";
            // 
            // makeShapeToolStripMenuItem
            // 
            this.makeShapeToolStripMenuItem.Name = "makeShapeToolStripMenuItem";
            this.makeShapeToolStripMenuItem.Size = new System.Drawing.Size(32, 19);
            // 
            // toolStrip1
            // 
            this.toolStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ActionMovePointsBtn,
            this.ActionAddPointsBtn,
            this.ActionAddLinesBtn,
            this.snapToGridPermanentButton,
            this.toolStripSeparator3,
            this.showHidePoints,
            this.showHideLines,
            this.showHideTriangles,
            this.showHidefilledtriangles,
            this.showHideShapes,
            this.showHideCircles,
            this.toolStripSeparator4,
            this.toolStripButtonZoomtoFeature,
            this.toolStripSeparator1,
            this.toolStripLabel1,
            this.toolStripZoomTextBox,
            this.toolStripSeparator2,
            this.toolStripLabel2,
            this.toolStripLayerComboBox,
            this.toolStripButton1,
            this.toolStripButton2});
            this.toolStrip1.Location = new System.Drawing.Point(0, 24);
            this.toolStrip1.Name = "toolStrip1";
            this.toolStrip1.Size = new System.Drawing.Size(956, 25);
            this.toolStrip1.TabIndex = 1;
            this.toolStrip1.Text = "toolStrip1";
            // 
            // ActionMovePointsBtn
            // 
            this.ActionMovePointsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ActionMovePointsBtn.Image = ((System.Drawing.Image)(resources.GetObject("ActionMovePointsBtn.Image")));
            this.ActionMovePointsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ActionMovePointsBtn.Name = "ActionMovePointsBtn";
            this.ActionMovePointsBtn.Size = new System.Drawing.Size(23, 22);
            this.ActionMovePointsBtn.Text = "Move";
            this.ActionMovePointsBtn.Click += new System.EventHandler(this.ActionMovePointsBtn_Click);
            // 
            // ActionAddPointsBtn
            // 
            this.ActionAddPointsBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ActionAddPointsBtn.Image = ((System.Drawing.Image)(resources.GetObject("ActionAddPointsBtn.Image")));
            this.ActionAddPointsBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ActionAddPointsBtn.Name = "ActionAddPointsBtn";
            this.ActionAddPointsBtn.Size = new System.Drawing.Size(23, 22);
            this.ActionAddPointsBtn.Text = "Add vertex";
            this.ActionAddPointsBtn.Click += new System.EventHandler(this.ActionAddPointsBtn_Click);
            // 
            // ActionAddLinesBtn
            // 
            this.ActionAddLinesBtn.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.ActionAddLinesBtn.Image = ((System.Drawing.Image)(resources.GetObject("ActionAddLinesBtn.Image")));
            this.ActionAddLinesBtn.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ActionAddLinesBtn.Name = "ActionAddLinesBtn";
            this.ActionAddLinesBtn.Size = new System.Drawing.Size(23, 22);
            this.ActionAddLinesBtn.Text = "Add line";
            this.ActionAddLinesBtn.Click += new System.EventHandler(this.ActionAddLinesBtn_Click);
            // 
            // snapToGridPermanentButton
            // 
            this.snapToGridPermanentButton.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.snapToGridPermanentButton.Image = ((System.Drawing.Image)(resources.GetObject("snapToGridPermanentButton.Image")));
            this.snapToGridPermanentButton.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.snapToGridPermanentButton.Name = "snapToGridPermanentButton";
            this.snapToGridPermanentButton.Size = new System.Drawing.Size(23, 22);
            this.snapToGridPermanentButton.Text = "Toggle grid snap";
            // 
            // toolStripSeparator3
            // 
            this.toolStripSeparator3.Name = "toolStripSeparator3";
            this.toolStripSeparator3.Size = new System.Drawing.Size(6, 25);
            // 
            // showHidePoints
            // 
            this.showHidePoints.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showHidePoints.Image = ((System.Drawing.Image)(resources.GetObject("showHidePoints.Image")));
            this.showHidePoints.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showHidePoints.Name = "showHidePoints";
            this.showHidePoints.Size = new System.Drawing.Size(23, 22);
            this.showHidePoints.Text = "Show points";
            this.showHidePoints.Click += new System.EventHandler(this.ShowHideItemsClick);
            // 
            // showHideLines
            // 
            this.showHideLines.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showHideLines.Image = ((System.Drawing.Image)(resources.GetObject("showHideLines.Image")));
            this.showHideLines.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showHideLines.Name = "showHideLines";
            this.showHideLines.Size = new System.Drawing.Size(23, 22);
            this.showHideLines.Text = "Show lines";
            this.showHideLines.Click += new System.EventHandler(this.ShowHideItemsClick);
            // 
            // showHideTriangles
            // 
            this.showHideTriangles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showHideTriangles.Image = ((System.Drawing.Image)(resources.GetObject("showHideTriangles.Image")));
            this.showHideTriangles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showHideTriangles.Name = "showHideTriangles";
            this.showHideTriangles.Size = new System.Drawing.Size(23, 22);
            this.showHideTriangles.Text = "Show triangles";
            this.showHideTriangles.Click += new System.EventHandler(this.ShowHideItemsClick);
            // 
            // showHidefilledtriangles
            // 
            this.showHidefilledtriangles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showHidefilledtriangles.Image = ((System.Drawing.Image)(resources.GetObject("showHidefilledtriangles.Image")));
            this.showHidefilledtriangles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showHidefilledtriangles.Name = "showHidefilledtriangles";
            this.showHidefilledtriangles.Size = new System.Drawing.Size(23, 22);
            this.showHidefilledtriangles.Text = "Show filled triangles";
            this.showHidefilledtriangles.Click += new System.EventHandler(this.ShowHideItemsClick);
            // 
            // showHideShapes
            // 
            this.showHideShapes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showHideShapes.Image = ((System.Drawing.Image)(resources.GetObject("showHideShapes.Image")));
            this.showHideShapes.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showHideShapes.Name = "showHideShapes";
            this.showHideShapes.Size = new System.Drawing.Size(23, 22);
            this.showHideShapes.Text = "Show shapes";
            this.showHideShapes.Click += new System.EventHandler(this.ShowHideItemsClick);
            // 
            // showHideCircles
            // 
            this.showHideCircles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.showHideCircles.Image = ((System.Drawing.Image)(resources.GetObject("showHideCircles.Image")));
            this.showHideCircles.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.showHideCircles.Name = "showHideCircles";
            this.showHideCircles.Size = new System.Drawing.Size(23, 22);
            this.showHideCircles.Text = "Show circles";
            this.showHideCircles.Click += new System.EventHandler(this.ShowHideItemsClick);
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel1
            // 
            this.toolStripLabel1.Name = "toolStripLabel1";
            this.toolStripLabel1.Size = new System.Drawing.Size(39, 22);
            this.toolStripLabel1.Text = "Zoom";
            // 
            // toolStripZoomTextBox
            // 
            this.toolStripZoomTextBox.Name = "toolStripZoomTextBox";
            this.toolStripZoomTextBox.Size = new System.Drawing.Size(100, 25);
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 25);
            // 
            // toolStripLabel2
            // 
            this.toolStripLabel2.Name = "toolStripLabel2";
            this.toolStripLabel2.Size = new System.Drawing.Size(35, 22);
            this.toolStripLabel2.Text = "Layer";
            // 
            // toolStripLayerComboBox
            // 
            this.toolStripLayerComboBox.Name = "toolStripLayerComboBox";
            this.toolStripLayerComboBox.Size = new System.Drawing.Size(121, 25);
            this.toolStripLayerComboBox.SelectedIndexChanged += new System.EventHandler(this.toolStripLayerComboBox_SelectedIndexChanged);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton1.Text = "toolStripButton1";
            this.toolStripButton1.Click += new System.EventHandler(this.toolStripButton1_Click);
            // 
            // toolStripButton2
            // 
            this.toolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButton2.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton2.Image")));
            this.toolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton2.Name = "toolStripButton2";
            this.toolStripButton2.Size = new System.Drawing.Size(23, 22);
            this.toolStripButton2.Text = "toolStripButton2";
            this.toolStripButton2.Click += new System.EventHandler(this.toolStripButton2_Click);
            // 
            // mainPanel
            // 
            this.mainPanel.Dock = System.Windows.Forms.DockStyle.Fill;
            this.mainPanel.Location = new System.Drawing.Point(0, 49);
            this.mainPanel.Name = "mainPanel";
            this.mainPanel.Size = new System.Drawing.Size(956, 469);
            this.mainPanel.TabIndex = 2;
            // 
            // toolStripButtonZoomtoFeature
            // 
            this.toolStripButtonZoomtoFeature.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image;
            this.toolStripButtonZoomtoFeature.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButtonZoomtoFeature.Image")));
            this.toolStripButtonZoomtoFeature.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButtonZoomtoFeature.Name = "toolStripButtonZoomtoFeature";
            this.toolStripButtonZoomtoFeature.Size = new System.Drawing.Size(23, 22);
            this.toolStripButtonZoomtoFeature.Text = "toolStripButton3";
            this.toolStripButtonZoomtoFeature.Click += new System.EventHandler(this.toolStripButtonZoomtoFeature_Click);
            // 
            // toolStripSeparator4
            // 
            this.toolStripSeparator4.Name = "toolStripSeparator4";
            this.toolStripSeparator4.Size = new System.Drawing.Size(6, 25);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(956, 518);
            this.Controls.Add(this.mainPanel);
            this.Controls.Add(this.toolStrip1);
            this.Controls.Add(this.menuStrip1);
            this.MainMenuStrip = this.menuStrip1;
            this.Name = "MainForm";
            this.Text = "Blueprint";
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.toolStrip1.ResumeLayout(false);
            this.toolStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem fileToolStripMenuItem;
        private System.Windows.Forms.ToolStrip toolStrip1;
        private System.Windows.Forms.ToolStripButton ActionMovePointsBtn;
        private System.Windows.Forms.ToolStripButton ActionAddPointsBtn;
        private System.Windows.Forms.ToolStripButton ActionAddLinesBtn;
        private System.Windows.Forms.ToolStripButton snapToGridPermanentButton;
        private System.Windows.Forms.ToolStripMenuItem newToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem backgroundToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem solidColorToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem gridToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripLabel toolStripLabel1;
        private System.Windows.Forms.ToolStripTextBox toolStripZoomTextBox;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripLabel toolStripLabel2;
        private System.Windows.Forms.ToolStripComboBox toolStripLayerComboBox;
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripButton toolStripButton2;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator3;
        private System.Windows.Forms.ToolStripButton showHidePoints;
        private System.Windows.Forms.ToolStripButton showHideLines;
        private System.Windows.Forms.ToolStripButton showHideTriangles;
        private System.Windows.Forms.ToolStripButton showHidefilledtriangles;
        private System.Windows.Forms.ToolStripButton showHideShapes;
        private System.Windows.Forms.ToolStripButton showHideCircles;
        private System.Windows.Forms.ToolStripMenuItem scientificToolStripMenuItem;
        private System.Windows.Forms.Panel mainPanel;
        private System.Windows.Forms.ToolStripMenuItem actionsToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem makeShapeToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem2;
        private System.Windows.Forms.ToolStripSeparator toolStripMenuItem1;
        private System.Windows.Forms.ToolStripMenuItem labelOverlayToolStripMenuItem;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator4;
        private System.Windows.Forms.ToolStripButton toolStripButtonZoomtoFeature;
    }
}

