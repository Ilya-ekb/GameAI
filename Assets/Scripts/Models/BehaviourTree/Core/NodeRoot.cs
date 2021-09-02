using Models.CharacterModel;
using Models.CharacterModel.Behaviour;
using System.Collections.Generic;

namespace BehaviourTree.Core
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

        /// <summary>
        /// Node type
        /// </summary>
        protected NodeType nodeType;
        /// <summary>
        /// Node index in sequence
        /// </summary>
        private int nodeIndex;

        protected List<NodeRoot> nodeChildList = new List<NodeRoot>();

        public NodeRoot(NodeType nodeType)
        {
            this.nodeType = nodeType;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns>Return type of execution result</returns>

        /// <summary>
        /// Current character execution node abstract method
        /// </summary>
        /// <param name="character">Current character</param>
        /// <returns>Return type of execution result</returns>
        public abstract ResultType Execute(ICharacter character);
    }
}