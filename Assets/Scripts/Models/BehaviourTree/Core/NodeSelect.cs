using BehaviourTree.Data;

using Models.CharacterModel;

namespace BehaviourTree.Core
{
    public class NodeSelect : NodeCombiner
    {
        private NodeRoot lastRunningNode;

        public NodeSelect(NodeData data) : base(NodeType.Select, data) 
        {
        }

        /// <summary>
        ///  Select the node to traverse all the child nodes in turn, if all return Fail, then return Fail to the parent node
        ///  Until a node returns Success or Running, stop the execution of subsequent nodes and report to the parent node
        ///  Return Success or Running
        ///  Note: If the node returns to Running, you need to remember this node, and execute it directly from this node next time
        /// </summary>
        /// <returns></returns>
        public override ResultType Execute(ICharacter character)
        {
            var index = 0;
            if (lastRunningNode != null)
            {
                index = lastRunningNode.NodeIndex;
            }
            lastRunningNode = null;

            var result = ResultType.Fail;

            for (var i = index; i < nodeChildList.Count; i++)
            {
                var nodeRoot = nodeChildList[i];
                result = nodeRoot.Execute(character);
                if (result == ResultType.Fail)
                {
                    continue;
                }
                if (result == ResultType.Success)
                {
                    break;
                }
                if (result == ResultType.Running)
                {
                    lastRunningNode = nodeRoot;
                    break;
                }
            }

            return result;
        }
    }
}