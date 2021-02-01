using System.Collections.Generic;
using System.Drawing;
using System.Reflection;
using BlueprintAddon;
using TrigonometryLib.Primitives;

namespace BlueprintFlow.Nodes
{
    public class NodeBase : Primitive2D, ICustomDrawable, ICustomSelectable, ILinkable
    {
        private class NodeIOWrapper
        {
            public Rectangle2D localPosition;
            public string displayName;
            public NodeIOWrapper(string name, Rectangle2D pos)
            {
                displayName = name;
                localPosition = pos;
            }
        }
        private class NodeInputWrapper : NodeIOWrapper
        {
            public NodeInput input;
            public NodeInputWrapper(string name, Rectangle2D pos, NodeInput inp)
                : base(name, pos)
            {
                input = inp;
            }
        }
        private class NodeOutputWrapper : NodeIOWrapper
        {
            public NodeOutput output;
            public NodeOutputWrapper(string name, Rectangle2D pos, NodeOutput outp)
                : base(name, pos)
            {
                output = outp;
            }
        }


        private string Name { get { return "Yata"; } }
        private List<NodeInputWrapper> inputs = new List<NodeInputWrapper>();
        private List<NodeOutputWrapper> outputs = new List<NodeOutputWrapper>();

        private Rectangle2D rectangle = new Rectangle2D(new Vector2D(0.0f, 0.0f), new Vector2D(64.0f, 128.0f));
        private double ioOffset = 128;
        private double ioSize = 16;

        public void Draw(IRenderContext context, bool isSelected)
        {
            Vector2D p1 = context.PointToScreen(rectangle.topLeft);
            Vector2D p2 = rectangle.Size * context.DrawScale;
            context.Graphics.FillRectangle(new Rectangle2D(p1, p2), isSelected ? Color.Blue : Color.Red);


            double fontSize = 10.0 * context.DrawScale;
            Font font = new Font("Arial", (float)fontSize);
            if (fontSize > 1.0f)
                context.Graphics.DrawString(Name, font, Color.Wheat, context.PointToScreen(rectangle.topLeft));

            for (int i = 0; i < inputs.Count; i++)
            {
                Vector2D r1 = context.PointToScreen(inputs[i].localPosition.topLeft + rectangle.topLeft);
                Vector2D r2 = inputs[i].localPosition.Size * context.DrawScale;

                context.Graphics.DrawEllipse(new Rectangle2D(r1, r2), Color.GreenYellow, 3);

                if (fontSize > 1.0f)
                    context.Graphics.DrawString("In", font, Color.Wheat, new Vector2D(r1.x + r2.x, r1.y));
            }

            for (int i = 0; i < outputs.Count; i++)
            {
                Vector2D r1 = context.PointToScreen(outputs[i].localPosition.topLeft + rectangle.topLeft);
                Vector2D r2 = outputs[i].localPosition.Size * context.DrawScale;

                context.Graphics.DrawEllipse(new Rectangle2D(r1, r2), Color.Honeydew, 3);

                if (fontSize > 1.0f)
                {
                    Vector2D size = context.Graphics.MeasureString("Out", font);
                    context.Graphics.DrawString("Out", font, Color.Wheat, new Vector2D(r1.x - size.x, r1.y));
                }
            }
        }

        public NodeBase(string Name)
        {
            FillIOList();
        }

        public bool Select(Vector2D location, double zoomCorrection)
        {
            return rectangle.IsInside(location);
        }

        public void Move(Vector2D delta)
        {
            rectangle.Move(delta);
        }

        private void FillIOList()
        {
            FieldInfo[] members = GetType().GetFields();
            foreach (FieldInfo member in members)
            {
                NodeIOAttribute attrib = member.GetCustomAttribute<NodeIOAttribute>(true);
                if (attrib != null)
                {
                    if (member.FieldType == typeof(NodeInput))
                        inputs.Add(new NodeInputWrapper(attrib.Name, new Rectangle2D(0.0f, 0.0f, ioSize, ioSize), (NodeInput)member.GetValue(this)));

                    if (member.FieldType == typeof(NodeOutput))
                        outputs.Add(new NodeOutputWrapper(attrib.Name, new Rectangle2D(0.0f, 0.0f, ioSize, ioSize), (NodeOutput)member.GetValue(this)));
                }
            }



            int ioCount = inputs.Count + outputs.Count;
            rectangle = new Rectangle2D(new Vector2D(0.0f, 0.0f), new Vector2D(ioOffset, ioOffset) + new Vector2D(0.0f, ioCount * ioSize));

            for (int i = 0; i < inputs.Count; i++)
                inputs[i].localPosition.Move(new Vector2D(0.0f, ioOffset + (i * ioSize)));
            
            for (int i = 0; i < outputs.Count; i++)
                outputs[i].localPosition.Move(new Vector2D(rectangle.Width - ioSize, (inputs.Count * ioSize) + ioOffset + (i * ioSize)));
        }

        private NodeIOWrapper GetIOFromLocation(Vector2D location)
        {
            for (int i = 0; i < inputs.Count; i++)
            {
                Rectangle2D r = new Rectangle2D(inputs[i].localPosition);
                r.Move(rectangle.topLeft);
                if (r.IsInside(location))
                {
                    return inputs[i];
                }
            }

            for (int i = 0; i < outputs.Count; i++)
            {
                Rectangle2D r = new Rectangle2D(outputs[i].localPosition);
                r.Move(rectangle.topLeft);
                if (r.IsInside(location))
                {
                    return outputs[i];
                }
            }
            return null;
        }

        public object StartLink(Vector2D location)
        {
            return GetIOFromLocation(location);
        }

        public bool EndLink(Vector2D location, object linkObject)
        {
            NodeIOWrapper wrapper = GetIOFromLocation(location);

            NodeInputWrapper inp = wrapper as NodeInputWrapper;
            NodeOutputWrapper outp = linkObject as NodeOutputWrapper;

            if ((wrapper == null) || (linkObject == null))
            {
                inp = linkObject as NodeInputWrapper;
                outp = wrapper as NodeOutputWrapper;
                if ((wrapper == null) || (linkObject == null))
                {
                    return false;
                }
            }
            throw new System.Exception("LINKING");
            return true;
        }
    }
}
