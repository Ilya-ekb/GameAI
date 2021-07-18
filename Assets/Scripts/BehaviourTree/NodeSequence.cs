namespace BehaviourTree
{
    /// <summary>
    /// Sequence node (combine node)
    /// </summary>
    public class NodeSequence : NodeCombiner
    {
        private NodeRoot lastRunningNode;
        public NodeSequence() : base(NodeType.Sequence) { }

        /// <summary>
        ///  The sequence node executes the child nodes once, as long as the node returns Success, it continues to execute the subsequent nodes until a node
        ///  Return Fail or Running, stop executing subsequent nodes, and return Fail or Running to the parent node, if
        ///  All nodes return Success, then return Success to the parent node
        ///  Just like selecting a node, if a node returns Running, you need to record the node, and directly from the
        ///  Node starts execution
        /// </summary>
        /// <returns></returns>
        public override ResultType Execute()
        {
            int index = 0;
            if(lastRunningNode != null)
            {
                index = lastRunningNode.NodeIndex;
            }
            lastRunningNode = null;
            ResultType result = ResultType.Fail;

            for (int i = index; i < nodeChildList.Count; i++)
            {
                NodeRoot nodeRoot = nodeChildList[i];
                result = nodeRoot.Execute();
                if(result == ResultType.Fail)
                {
                    break;
                }
                if(result == ResultType.Running)
                {
                    lastRunningNode = nodeRoot;
                    break;
                }
                if(result == ResultType.Success)
                {
                    continue;
                }
            }

            return result;
        }
    }
}