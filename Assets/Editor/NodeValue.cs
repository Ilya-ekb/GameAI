using System;
using System.Collections.Generic;

using BehaviourTree;

using UnityEngine;

[Serializable]
public class NodeValue 
{
    public bool IsRootNode = false;
    public NodeType NodeType = NodeType.Select;
    public List<NodeValue> ChildNodeList = new List<NodeValue>();

    public string Name = string.Empty;
    public string Description = string.Empty;

    public Rect WindowRect = new Rect(.0f, .0f, 100.0f, 100.0f);

    public bool IsRelease = false;  

    public void Release()
    {
        IsRelease = true;
    }
}
