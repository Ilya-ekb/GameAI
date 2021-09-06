using System;
using System.Collections.Generic;
using System.Linq;
using UnityEditor;

using UnityEngine;
using UnityEngine.Windows;

namespace BehaviourTree.Data
{
    [Serializable]
    public class NodeAsset : ScriptableObject
    {
        [SerializeField] private string directoryPath = "Assets/BehaviourTreeAssets";

        public NodeData NodeData => nodeValue;
        [SerializeField] private NodeData nodeValue = null;

        public void FullAsset(string name, NodeData rootNode)
        {
            if (rootNode != null)
            {
                this.name = name;
                nodeValue = rootNode;
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

        public List<NodeData> ReturnNodeList(NodeData data)
        {
            var result = new List<NodeData>();
            foreach (var list in data.ChildNodeDataList.Select(ReturnNodeList).Where(list => list != null))
            {
                result.AddRange(list);
            }

            if (data.ChildNodeDataList.Count <= 0)
            {
                return null;
            }
            result.AddRange(data.ChildNodeDataList);
            result.Add(data);
            return result;
        }
    }
}
