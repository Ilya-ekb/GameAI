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
        /// <summary>
        /// Node index in sequence
        /// </summary>
        public int NodeIndex { get; set; }

        /// <summary>
        /// Node type
        /// </summary>
        protected NodeType nodeType;

        protected List<NodeRoot> nodeChildList = new List<NodeRoot>();

        protected NodeRoot(NodeType nodeType)
        {
            this.nodeType = nodeType;
        }

        /// <summary>
        /// Current character execution node abstract method
        /// </summary>
        /// <param name="character">Current character</param>
        /// <returns>Return type of execution result</returns>
        public abstract ResultType Execute(ICharacter character);
    }
}