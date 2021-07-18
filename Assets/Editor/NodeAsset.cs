using System;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;
using UnityEngine.Windows;

[Serializable]
public class NodeAsset : ScriptableObject
{
    public NodeValue NodeValue => nodeValue;
    [SerializeField] private NodeValue nodeValue = null;

    public void FullAsset(string name, NodeValue rootNode)
    {
        if (rootNode != null)
        {
            this.name = name;
            nodeValue = rootNode;
            string directoryPath = "Assets/BehaviourTreeAssets";
            if (!Directory.Exists(directoryPath))
            {
                Directory.CreateDirectory(directoryPath);
            }
            if (AssetDatabase.Contains(this))
            {
                AssetDatabase.RenameAsset(AssetDatabase.GetAssetPath(this), $"{name}.asset");
            }
            else
            {
                AssetDatabase.CreateAsset(this, $"{directoryPath}/{name}.asset");
            }
            AssetDatabase.SaveAssets();
            Selection.activeObject = this;
        }
        else
        {
            Debug.LogError($"{name} is not exist root node");
        }
    }

    public List<NodeValue> ReturnNodeList(NodeValue nodeValue)
    {
        var result = new List<NodeValue>();
        foreach(var nv in nodeValue.ChildNodeList)
        {
            var list = ReturnNodeList(nv);
            if (list != null)
            {
                result.AddRange(list);
            }
        }
        if (nodeValue.ChildNodeList.Count > 0)
        {
            result.AddRange(nodeValue.ChildNodeList);
            result.Add(nodeValue);
            return result;
        }
        return null;
    }
}
