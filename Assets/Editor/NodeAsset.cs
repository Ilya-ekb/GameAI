using System;
using UnityEngine;

[Serializable]
public class NodeAsset : ScriptableObject
{
    public NodeValue NodeValue => nodeValue;
    [SerializeField] private NodeValue nodeValue = null;
}
