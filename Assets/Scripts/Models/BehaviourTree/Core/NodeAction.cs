
using BehaviourTree.Data;

namespace BehaviourTree.Core
{
    /// <summary>
    /// Behaviour node (leaf node)
    /// </summary>
    public class NodeAction : NodeLeaf
    {
        public NodeAction(NodeData data) : base(NodeType.Action, data) { }
    }
}
