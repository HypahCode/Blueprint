using BlueprintFlow.Nodes;

namespace BlueprintFlow.Imaging
{
    public class ImageNode : NodeBase
    {
        [NodeIO("Input")]
        public NodeInput input1 = new NodeInput();

        [NodeIO("Output")]
        public NodeOutput output1 = new NodeOutput();

        public ImageNode()
            : base("My node")
        { }
    }
}
