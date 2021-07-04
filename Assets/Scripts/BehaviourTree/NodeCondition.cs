namespace BehaviourTree
{
    public abstract class NodeCondition : NodeRoot
    {
        /// <summary>
        /// Condition node (leaf node)
        /// </summary>
        public NodeCondition() : base(NodeType.Condition) { }   
    }
}
