using Models.Character;
using Models.Character.Behaviour;
using System.Collections.Generic;

namespace BehaviourTree
{
    /// <summary>
    /// Node abstract class
    /// </summary>
    public abstract class NodeRoot
    {
        public int NodeIndex
        {
            get => nodeIndex;
            set => nodeIndex = value;
        }

        public IAction Action { get => action; set => action = value; }

        /// <summary>
        /// Node type
        /// </summary>
        protected NodeType nodeType;
        /// <summary>
        /// Node index in sequence
        /// </summary>
        private int nodeIndex;

        protected List<NodeRoot> nodeChildList = new List<NodeRoot>();

        private IAction action;

        public NodeRoot(NodeType nodeType)
        {
            this.nodeType = nodeType;
        }

        /// <summary>
        /// Execution node abstract method
        /// </summary>
        /// <returns>Return type of execution result</returns>
        public virtual ResultType Execute(ICharacter character)
        {
            return action is null ? ResultType.Fail : action.Do(character);
        }
    }
}