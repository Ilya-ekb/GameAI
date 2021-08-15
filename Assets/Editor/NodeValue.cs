using System.Collections.Generic;
using BehaviourTree;
using Models.Character.Behaviour;
using UnityEngine;

[System.Serializable]
public class NodeValue 
{
    public bool IsRootNode { get => isRootNode; set => isRootNode = value; }
    public NodeType NodeType { get => nodeType; set => nodeType = value; }
    public Action Action { get => action; set => action = value; }
    public List<NodeValue> ChildNodeList => childNodeList;
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
    [SerializeField] private List<NodeValue> childNodeList = new List<NodeValue>();
    [SerializeField] private Action action;

    [SerializeField] private string name = string.Empty;
    [SerializeField] private string description = string.Empty;

    [SerializeField] private Rect windowRect;

    [SerializeField] private bool isRelease = false;

    public void Release()
    {
        isRelease = true;
    }
}
