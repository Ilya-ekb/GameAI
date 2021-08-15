using Models.Character;

namespace BehaviourTree
{
    /// <summary>
    /// Modification node (combiner node)
    /// </summary>
    public class NodeDecorator : NodeCombiner
    {
        private ResultType untilResultType = ResultType.Fail;

        public NodeDecorator() : base(NodeType.Decorator) { }

        /// <summary>
        /// Has only one child node, executing until result == untilResultType
        /// if result != untilResultType then return Running
        /// </summary>
        /// <returns></returns>
        public override ResultType Execute(ICharacter character)
        {
            NodeRoot nodeRoot = nodeChildList[0];
            ResultType result = nodeRoot.Execute(character);
            if (result != untilResultType)
            {
                return ResultType.Running;
            }

            return result;
        }

        public void SetUntilResultType(ResultType resultType)
        {
            untilResultType = resultType;
        }
    }
}