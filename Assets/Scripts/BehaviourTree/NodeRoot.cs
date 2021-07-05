
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
        public List<NodeRoot> ChildNodeList => nodeChildList;
        public Rect WindowRect { get => windowRect; set => windowRect = value; }
        /// <summary>
        ///  Whether it is a valid node, isRelease = true is a destroyed node, it is an invalid node
        /// </summary>
        public bool IsRelease => isRelease;

        /// <summary>
        /// Node type
        /// </summary>
        protected NodeType nodeType;
        /// <summary>
        /// Node index in sequence
        /// </summary>
        private int nodeIndex;
        private bool isRelease = false;
        private Rect windowRect = new Rect(0, 0, 100, 100);

        protected List<NodeRoot> nodeChildList = new List<NodeRoot>();

        public NodeRoot(NodeType nodeType)
        {
            this.nodeType = nodeType;
        }
        /// <summary>
        /// Called when a node is deleted
        /// </summary>
        public void Release()
        {
            isRelease = true;
        }

        /// <summary>
        /// Execution node abstract method
        /// </summary>
        /// <returns>Return type of execution result</returns>
        public abstract ResultType Execute();
    }
}