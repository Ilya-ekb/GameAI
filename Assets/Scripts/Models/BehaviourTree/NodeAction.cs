
namespace BehaviourTree
{
    /// <summary>
    /// Behaviour node (leaf node)
    /// </summary>
    public abstract class NodeAction : NodeLeaf
    {
        public NodeAction() : base(NodeType.Action) { }
    }
}
