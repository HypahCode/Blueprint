using System;

namespace BlueprintFlow.Nodes
{
    [AttributeUsage(AttributeTargets.Field | AttributeTargets.Property, AllowMultiple = false)]
    public class NodeIOAttribute : Attribute
    {
        public NodeIOAttribute(string name)
        {
            Name = name;
        }

        public string Name { get; private set; }
    }
}
