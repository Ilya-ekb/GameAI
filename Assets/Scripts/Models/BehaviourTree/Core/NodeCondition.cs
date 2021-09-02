using BehaviourTree.Data;

namespace BehaviourTree.Core
{
    public class NodeCondition : NodeLeaf
    {
        /// <summary>
        /// Condition node (leaf node)
        /// </summary>
        public NodeCondition(NodeData data) : base(NodeType.Condition, data) { }   
    }
}
