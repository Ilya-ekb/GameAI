using BehaviourTree.Data;
using Models.CharacterModel;

namespace BehaviourTree.Core
{
    /// <summary>
    /// Parallel node (comdiner node)
    /// </summary>
    public class NodeParallel : NodeCombiner
    {
        public NodeParallel(NodeData data) : base(NodeType.Parallel, data) { }

        /// <summary>
        /// Execute all child nodes at same time, until one node return Fail or all nodes return Success
        /// It returns Fail or Success to the parent node and terminates the execution of other nodes
        /// </summary>
        /// <returns></returns>
        public override ResultType Execute(ICharacter character)
        {
            var result = ResultType.Fail;
            var successCount = 0;
            foreach (var nodeRoot in nodeChildList)
            {
                result = nodeRoot.Execute(character);

                if(result == ResultType.Fail)
                {
                    break;
                }
                if(result == ResultType.Success)
                {
                    successCount++;
                }
                if(result == ResultType.Running)
                {
                    continue;
                }
            }

            if (result != ResultType.Fail)
            {
                result = successCount >= nodeChildList.Count ? ResultType.Success : ResultType.Running;
            }

            return result;

        }
    }
}