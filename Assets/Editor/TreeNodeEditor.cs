using System;
using System.Collections.Generic;
using System.Linq;
using BehaviourTree.Core;
using BehaviourTree.Data;
using Models;
using Models.CharacterModel.Behaviour;
using NUnit.Framework;
using UnityEditor;
using UnityEngine;

namespace Assets.Editor
{
    public class TreeNodeEditor : EditorWindow
    {
        // Save all nodes in the window
        private List<NodeData> nodeRootList = new List<NodeData>();
        
        // currently selected node
        private NodeData selectNode = null;
        private List<OffsetData> selectNodeChildsOffsets = new List<OffsetData>();
        private List<NodeData> selectNodeChild= new List<NodeData>();

        private NodeAsset asset;
        private string assetName = string.Empty;

        [MenuItem("Window/Behaviour Tree")]
        private static void ShowWindow()
        {
            TreeNodeEditor window = EditorWindow.GetWindow<TreeNodeEditor>();
        }

        // mouse position
        private Vector2 mousePosition;

        // Add connection
        private bool makeTransitionMode;

        private void OnGUI()
        {
            Event _event = Event.current;
            mousePosition = _event.mousePosition;

            if (nodeRootList != null)
            {
                //Traverse all nodes and remove invalid nodes
                for (var i = nodeRootList.Count - 1; i >= 0; --i)
                {
                    if (nodeRootList[i].IsRelease)
                    {
                        nodeRootList.RemoveAt(i);
                    }
                }
            }

            if (_event.button == 1) // right click
            {
                if (_event.type == EventType.MouseDown)
                {
                    if (!makeTransitionMode)
                    {
                        var clickedOnNode = false;
                        selectNode = GetMouseInNode(out var selectIndex);
                        clickedOnNode = (selectNode != null);

                        ShowMenu(!clickedOnNode ? 0 : 1);
                    }
                }
            }

            if (_event.button == 0) // left click
            {
                switch (_event.type)
                {
                    case EventType.MouseDown:
                        if (!makeTransitionMode)
                        {
                            var clickedOnNode = false;
                            selectNode = GetMouseInNode(out var selectIndex);
                            clickedOnNode = (selectNode != null);
                            if (clickedOnNode)
                            {
                                ClearSelectChilds();
                                GetOffsets(selectNode);
                            }
                        }

                        break;
                    case EventType.MouseUp:
                        ClearSelectChilds();
                        selectNode = null;
                        break;
                }
            }


            if (selectNode != null)
            {
                SetOffsets();
            }

            DrawMainMenu();

            // Unable to connect when the selected node is empty
            if (selectNode == null)
            {
                makeTransitionMode = false;
            }

            if (!makeTransitionMode)
            {
                if (_event.type == EventType.MouseUp)
                {
                    selectNode = null;
                }
            }

            // In the connection state, press the mouse
            if (makeTransitionMode && _event.type == EventType.MouseDown)
            {
                var newSelectNode = GetMouseInNode(out var selectIndex);
                // If a node is selected when the mouse is pressed, the newly selected root node is added as a child node of selectNode
                if (selectNode != newSelectNode)
                {
                    selectNode.ChildNodeDataList.Add(newSelectNode);
                }

                // cancel connection status
                makeTransitionMode = false;
                // Clear the selection node
                selectNode = null;
            }

            // The selected node is not empty in the connected state 
            if (makeTransitionMode && selectNode != null)
            {
                // Get the mouse position
                var mouseRect = new Rect(mousePosition.x, mousePosition.y, 10, 10);
                // Show the line from the selected node to the mouse position
                DrawNodeCurve(selectNode.WindowRect, mouseRect);
            }

            // start drawing node 
            // Note: You must call GUI.Window between BeginWindows(); and EndWindows(); to display
            BeginWindows();
            for (int i = 0; i < nodeRootList?.Count; i++)
            {
                NodeData nodeRoot = nodeRootList[i];
                var showName = string.IsNullOrEmpty(nodeRoot.Name)
                    ? nodeRoot.NodeType.ToString() + " node "
                    : nodeRoot.Name;
                nodeRoot.WindowRect = GUI.Window(i, nodeRoot.WindowRect, DrawNodeWindow, showName);

                DrawToChildCurve(nodeRoot);
            }

            EndWindows();

            // repaint
            Repaint();
        }

        private void ClearSelectChilds()
        {
            selectNodeChild.Clear();
            selectNodeChildsOffsets.Clear();
        }

        private void SetOffsets()
        {
            for (var i = 0; i < selectNodeChild.Count; i++)
            {
                selectNodeChild[i].WindowRect = new Rect(selectNode.WindowRect.position + GetOffset(i),
                    selectNodeChild[i].WindowRect.size);
            }
        }

        private Vector2 GetOffset(int index)
        {
            return selectNodeChildsOffsets.Count > index ? selectNodeChildsOffsets[index].Offset : default;
        }

        private void GetOffsets(NodeData selectNode)
        {
            if (selectNode?.ChildNodeDataList == null)
            {
                return;
            }

            foreach (var childNodeData in selectNode.ChildNodeDataList)
            {
                selectNodeChild.Add(childNodeData);
                selectNodeChildsOffsets.Add(new OffsetData(selectNodeChildsOffsets.Count,
                    childNodeData.WindowRect.position - this.selectNode.WindowRect.position));
                GetOffsets(childNodeData);
            }
        }

        private void DrawMainMenu()
        {
            if (nodeRootList.Count > 0)
            {
                assetName = GUI.TextField(new Rect(Screen.width/2 - 260, 10, 200, 20), assetName);
                if(GUI.Button(new Rect(Screen.width - 110, 10, 100, 20), "Clear"))
                {
                    nodeRootList.Clear();
                    asset = null;
                }

                if(!string.IsNullOrEmpty(assetName) && GUI.Button(new Rect(Screen.width/2, 10, 100, 20), "Save"))
                {
                    if (!asset)
                    {
                        asset = CreateInstance<NodeAsset>();
                    }
                    asset.FullAsset(assetName, nodeRootList.Find(e => e.IsRootNode));
                }
            }
            else
            {
                assetName = string.Empty;
                asset = (NodeAsset)EditorGUI.ObjectField(new Rect(10, 10, 200, 20), asset, typeof(NodeAsset));
                if (!asset)
                {
                    return;
                }

                if (!GUI.Button(new Rect(220, 10, 100, 20), "Load"))
                {
                    return;
                }
                assetName = asset.name;
                nodeRootList = asset.ReturnNodeList(asset.NodeData);
            }
        }

        private bool selectedRoot;

        private void DrawNodeWindow(int id)
        {
            var nodeRoot = nodeRootList[id];
            nodeRoot.ShowName = GUI.Toggle(new Rect(2, 2, 10, 20), nodeRoot.ShowName, "", EditorStyles.miniButton);
            if (nodeRoot.ShowName)
            {
                nodeRoot.Name = GUILayout.TextField(nodeRoot.Name, 15);
            }
            nodeRoot.NodeType = (NodeType)EditorGUILayout.Popup((int)nodeRoot.NodeType, Enum.GetValues(typeof(NodeType)).Cast<NodeType>().Select(x => x.ToString()).ToArray());

            if (nodeRoot.NodeType == NodeType.Action)
            {
                nodeRoot.Action = (ActionEventObject)EditorGUILayout.ObjectField(nodeRoot.Action, typeof(ActionEventObject));
            }
            if(nodeRoot.NodeType == NodeType.Condition)
            {
                nodeRoot.Action = (ConditionEventObject)EditorGUILayout.ObjectField(nodeRoot.Action, typeof(ConditionEventObject));
            }
            if(nodeRoot.NodeType == NodeType.Sequence ||
               nodeRoot.NodeType == NodeType.Parallel ||
               nodeRoot.NodeType == NodeType.Select)
            {
                if (!selectedRoot || nodeRoot.IsRootNode)
                {
                    nodeRoot.IsRootNode = GUI.Toggle(new Rect(2, 40, 100, 20), nodeRoot.IsRootNode, " is Root Node");
                    selectedRoot = nodeRoot.IsRootNode;
                }

            }
            // The window that can be dragged
            GUI.DragWindow();

        }

        // Get the node where the mouse is
        private NodeData GetMouseInNode(out int index)
        {
            index = 0;
            NodeData selectRoot = null;
            for (int i = 0; i < nodeRootList.Count; i++)
            {
                NodeData nodeRoot = nodeRootList[i];
                // If the mouse position is included in the Rect range of the node, it is regarded as a selectable node
                if (nodeRoot.WindowRect.Contains(mousePosition))
                {
                    selectRoot = nodeRoot;
                    index = i;
                    break;
                }
            }

            return selectRoot;
        }

        private void ShowMenu(int type)
        {
            GenericMenu menu = new GenericMenu();
            if (type == 0)
            {
                // add a new node
                menu.AddItem(new GUIContent("Add new node"), false, AddNode);
            }
            else
            {
                // Connect child nodes
                menu.AddItem(new GUIContent("Make Transition"), false, MakeTransition);
                menu.AddSeparator("");
                // delete node
                menu.AddItem(new GUIContent("Delete Node"), false, DeleteNode);
            }

            menu.ShowAsContext();
            Event.current.Use();
        }

        // add node
        private void AddNode()
        {
            var nodeSelect = new NodeData
            {
                WindowRect = new Rect(mousePosition.x, mousePosition.y, 120, 100)
            };
            nodeRootList.Add(nodeSelect);
        }

        // Connect child nodes
        private void MakeTransition()
        {
            makeTransitionMode = true;
        }

        // delete node
        private void DeleteNode()
        {
            selectNode = GetMouseInNode(out var selectIndex);
            if (selectNode != null)
            {
                nodeRootList[selectIndex].Release();
                nodeRootList.Remove(selectNode);
            }
        }

        /// <summary>
        ///  Draw lines from the node to all child nodes every frame
        /// </summary>
        /// <param name="nodeRoot"></param>
        private static void DrawToChildCurve(NodeData nodeRoot)
        {
            for (var i = nodeRoot.ChildNodeDataList.Count - 1; i >= 0; --i)
            {
                var childNode = nodeRoot.ChildNodeDataList[i];
                // delete invalid nodes
                if (childNode == null || childNode.IsRelease)
                {
                    nodeRoot.ChildNodeDataList.RemoveAt(i);
                    continue;
                }
                DrawNodeCurve(nodeRoot.WindowRect, childNode.WindowRect, i);
            }
        }

        // draw line
        public static void DrawNodeCurve(Rect start, Rect end, int index = -1)
        {
            var startPos = new Vector3(start.x + start.width / 2, start.y + start.height, 0);
            var endPos = new Vector3(end.x + end.width / 2, end.y, 0);
            if(index != -1)
            {
                var style = new GUIStyle
                {
                    normal =
                    {
                        textColor = Color.red
                    },
                    fontSize = 8,
                    fontStyle = FontStyle.Bold
                };
                Handles.Label(endPos + Vector3.down + Vector3.left * end.width/1.8f, index.ToString(), style);
            }
            Handles.DrawLine(startPos, endPos);
        }

        private struct OffsetData
        {
            public Vector2 Offset => offset;
            public OffsetData(int index, Vector2 offset)
            {
                this.index = index;
                this.offset = offset;
            }

            private int index;
            private Vector2 offset;
        }
    }
}