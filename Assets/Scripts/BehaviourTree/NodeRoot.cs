
using System.Collections.Generic;

using UnityEngine;

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
        /// Execution node abstract method
        /// </summary>
        /// <returns>Return type of execution result</returns>
        public abstract ResultType Execute();
    }
}