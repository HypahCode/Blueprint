using System.Collections.Generic;
using System.Drawing;
using Blueprint.VectorImagess;
using BlueprintAddon;
using TrigonometryLib.Primitives;

namespace Blueprint.RenderEngine
{
    internal class PrimitiveRenderer : Renderer
    {
        internal LayeredVectorImage layeredImage = null;
        private bool isActive = false;

        internal override void Draw(RenderContext context)
        {
            base.Draw(context);

            if (layeredImage != null)
            {
                isActive = false;
                for (int i = 0; i < layeredImage.Count; i++)
                {
                    if (layeredImage.Get(i) != layeredImage.Image)
                    {
                        DrawPrimitiveList(context, layeredImage.Get(i).primitives);
                    }
                }

                isActive = true;
                DrawPrimitiveList(context, layeredImage.Image.primitives);
            }
        }

        private void DrawPrimitiveList(RenderContext context, List<Primitive2D> pList)
        {
            for (int i = 0; i < pList.Count; i++)
            {
                if (pList[i] is ICustomDrawable) ((ICustomDrawable)pList[i]).Draw(context, IsPrimitiveSelected(pList[i]));
                else if (pList[i] is Vector2D) DrawVector2D(context, pList[i] as Vector2D);
                else if (pList[i] is Line2D) DrawLine2D(context, pList[i] as Line2D);
                else if (pList[i] is Triangle2D) DrawTriangle2D(context, pList[i] as Triangle2D);
                else if (pList[i] is Circle2D) DrawCircle2D(context, pList[i] as Circle2D);
                else if (pList[i] is Shape2D) DrawShape2D(context, pList[i] as Shape2D);
                else if (pList[i] is ICompoundPrimitive2D) DrawPrimitiveList(context, (pList[i] as ICompoundPrimitive2D).GetPrimitives());
            }
        }

        private void DrawVector2D(RenderContext context, Vector2D v)
        {
            if (context.ShowPoints)
            {
                context.Graphics.DrawPoint(context.PointToScreen(v), GetColor(v, Colors.Vector2D), 3);
            }
        }

        private void DrawLine2D(RenderContext context, Line2D l)
        {
            if (context.ShowLines)
            {
                Vector2D p1 = context.PointToScreen(l.Start);
                Vector2D p2 = context.PointToScreen(l.End);
                context.Graphics.DrawLine(p1, p2, GetColor(l, Colors.Line2D), 2);
            }
        }

        private void DrawTriangle2D(RenderContext context, Triangle2D t)
        {
            if ((context.ShowTriangles) || (context.ShowFilledTriangles))
            {
                Vector2D a = context.PointToScreen(t.a);
                Vector2D b = context.PointToScreen(t.b);
                Vector2D c = context.PointToScreen(t.c);
                if (context.ShowFilledTriangles)
                {
                    context.Graphics.FillPolygon(new Vector2D[] { a, b, c }, GetColor(t, Colors.Triangle2DFilled));
                }
                if (context.ShowTriangles)
                {
                    context.Graphics.DrawLine(a, b, GetColor(t, Colors.Triangle2D), 2);
                    context.Graphics.DrawLine(b, c, GetColor(t, Colors.Triangle2D), 2);
                    context.Graphics.DrawLine(c, a, GetColor(t, Colors.Triangle2D), 2);
                }
            }

        }

        private void DrawCircle2D(RenderContext context, Circle2D c)
        {
            if (context.ShowCircles)
            {
                Vector2D p1 = context.PointToScreen(c.center - c.radius);
                int wh = (int)(c.radius * 2 * context.DrawScale);

                context.Graphics.DrawEllipse(new Rectangle2D(p1.x, p1.y, wh, wh), GetColor(c, Colors.Circle2D), 2);
            }
        }

        private void DrawShape2D(RenderContext context, Shape2D s)
        {
            if (context.ShowShapes)
            {
                List<Line2D> lines = s.GetLines();
                for (int i = 0; i < lines.Count; i++)
                {
                    Vector2D p1 = context.PointToScreen(lines[i].Start);
                    Vector2D p2 = context.PointToScreen(lines[i].End);
                    context.Graphics.DrawLine(p1, p2, GetColor(s, Colors.Shape2D), 2);
                }
            }
        }

        private Color GetColor(Primitive2D p, Colors.ColorPair defaultColors)
        {
            if (!isActive)
                return defaultColors.Inactive;

            PrimitiveRenderData data = p.GetData<PrimitiveRenderData>();
            if (data != null)
            {
                return data.isSelected ? defaultColors.Selected : data.GetColor(defaultColors.Active);
            }
            return defaultColors.Active;
        }

        private bool IsPrimitiveSelected(Primitive2D p)
        {
            PrimitiveRenderData data = p.GetData<PrimitiveRenderData>();
            if (data != null)
            {
                return data.isSelected;
            }
            return false;
        }
    }
}
