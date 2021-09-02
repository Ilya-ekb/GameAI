using System;
using System.Collections.Generic;

using UnityEditor;

using UnityEngine;
using UnityEngine.Windows;

namespace BehaviourTree.Data
{
    [Serializable]
    public class NodeAsset : ScriptableObject
    {
        public NodeData NodeData => nodeValue;
        [SerializeField] private NodeData nodeValue = null;

        public void FullAsset(string name, NodeData rootNode)
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

        public List<NodeData> ReturnNodeList(NodeData nodeValue)
        {
            var result = new List<NodeData>();
            foreach (var data in nodeValue.ChildNodeDataList)
            {
                var list = ReturnNodeList(data);
                if (list != null)
                {
                    result.AddRange(list);
                }
            }
            if (nodeValue.ChildNodeDataList.Count > 0)
            {
                result.AddRange(nodeValue.ChildNodeDataList);
                result.Add(nodeValue);
                return result;
            }
            return null;
        }
    }
}
