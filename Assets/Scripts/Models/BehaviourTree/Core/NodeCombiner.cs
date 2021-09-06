using BehaviourTree.Data;
using BehaviourTree.Implementor;

namespace BehaviourTree.Core
{
    /// <summary>
    /// Composite node
    /// </summary>
    public abstract class NodeCombiner : NodeRoot
    {
        public NodeCombiner(NodeType nodeType, NodeData data) : base(nodeType) 
        {
            if(data?.ChildNodeDataList != null)
            {
                foreach (var child in data.ChildNodeDataList)
                {
                    AddNode(BehaviourImplementor.GetBehaviourNode(child));
                }
            }
        }

        /// <summary>
        /// Add new child node
        /// </summary>
        /// <param name="nodeRoot"></param>
        private void AddNode(NodeRoot nodeRoot)
        {
            int count = nodeChildList.Count;
            nodeRoot.NodeIndex = count;
            nodeChildList.Add(nodeRoot);
        }
    }
}