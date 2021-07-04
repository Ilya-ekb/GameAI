namespace BehaviourTree
{
    /// <summary>
    /// Leaf node
    /// </summary>
    public abstract class NodeLeaf : NodeRoot
    {
        public NodeLeaf(NodeType nodeType) : base(nodeType) { }
    }
}
