using Models.Character;

namespace BehaviourTree
{
    /// <summary>
    /// Parallel node (comdiner node)
    /// </summary>
    public class NodeParallel : NodeCombiner
    {
        public NodeParallel() : base(NodeType.Parallel) { }

        /// <summary>
        /// Execute all child nodes at same time, until one node return Fail or all nodes return Success
        /// It returns Fail or Success to the parent node and terminates the execution of other nodes
        /// </summary>
        /// <returns></returns>
        public override ResultType Execute(ICharacter character)
        {
            ResultType result = ResultType.Fail;
            int successCount = 0;
            for(int i = 0; i < nodeChildList.Count; i++)
            {
                NodeRoot nodeRoot = nodeChildList[i];
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