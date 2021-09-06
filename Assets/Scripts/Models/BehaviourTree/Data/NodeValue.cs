using System.Collections.Generic;
using BehaviourTree.Core;
using Models.CharacterModel.Behaviour;
using UnityEngine;

namespace BehaviourTree.Data
{
    [System.Serializable]
    public class NodeData
    {
        public int Index { get; set; }
        public bool IsRootNode { get => isRootNode; set => isRootNode = value; }
        public NodeType NodeType { get => nodeType; set => nodeType = value; }
        public BaseEventObject Action { get => action; set => action = value; }
        public NodeData ParentNode { get; set; }
        public List<NodeData> ChildNodeDataList => childNodeDataList;
        public string Name { get => name; set => name = value; }
        public string Description { get => description; set => description = value; }
        public Rect WindowRect
        {
            get => windowRect;
            set
            {
                windowRect = value;
            }
        }
        public bool IsRelease => isRelease;

        public bool ShowName { get; set; }
        [SerializeField] private bool isRootNode = false;
        [SerializeField] private NodeType nodeType = NodeType.Select;
        [SerializeField] private List<NodeData> childNodeDataList = new List<NodeData>();
        [SerializeField] private BaseEventObject action;

        [SerializeField] private string name = string.Empty;
        [SerializeField] private string description = string.Empty;

        [SerializeField] private Rect windowRect;

        [SerializeField] private bool isRelease = false;

        public void Release()
        {
            isRelease = true;
        }
    }
}
