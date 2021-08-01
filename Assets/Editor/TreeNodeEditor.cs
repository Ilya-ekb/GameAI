using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using BehaviourTree;
using System;
using System.Linq;

public class TreeNodeEditor : EditorWindow
{
    // Save all nodes in the window
    private List<NodeValue> nodeRootList = new List<NodeValue>();
    // currently selected node
    private NodeValue selectNode = null;
    private NodeAsset asset;
    private string assetName = string.Empty;

    [MenuItem("Window/CreateTree")]
    static void ShowWindow()
    {
        TreeNodeEditor window = EditorWindow.GetWindow<TreeNodeEditor>();
    }

    // mouse position
    private Vector2 mousePosition;
    // Add connection
    private bool makeTransitionMode = false;
    private void OnGUI()
    {
        Event _event = Event.current;
        mousePosition = _event.mousePosition;

        //Traverse all nodes and remove invalid nodes
        for (int i = nodeRootList.Count - 1; i >= 0; --i)
        {
            if (nodeRootList[i].IsRelease)
            {
                nodeRootList.RemoveAt(i);
            }
        }

        if (_event.button == 1) // right click
        {
            if (_event.type == EventType.MouseDown)
            {
                if (!makeTransitionMode)
                {
                    bool clickedOnNode = false;
                    int selectIndex = 0;
                    selectNode = GetMouseInNode(out selectIndex);
                    clickedOnNode = (selectNode != null);

                    if (!clickedOnNode)
                    {
                        ShowMenu(0);
                    }
                    else
                    {
                        ShowMenu(1);
                    }
                }
            }
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
            int selectIndex = 0;
            NodeValue newSelectNode = GetMouseInNode(out selectIndex);
            // If a node is selected when the mouse is pressed, the newly selected root node is added as a child node of selectNode
            if (selectNode != newSelectNode)
            {
                selectNode.ChildNodeList.Add(newSelectNode);
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
            Rect mouseRect = new Rect(mousePosition.x, mousePosition.y, 10, 10);
            // Show the line from the selected node to the mouse position
            DrawNodeCurve(selectNode.WindowRect, mouseRect);
        }

        // start drawing node 
        // Note: You must call GUI.Window between BeginWindows(); and EndWindows(); to display
        BeginWindows();
        for (int i = 0; i < nodeRootList.Count; i++)
        {
            NodeValue nodeRoot = nodeRootList[i];
            nodeRoot.WindowRect = GUI.Window(i, nodeRoot.WindowRect, DrawNodeWindow, string.IsNullOrEmpty(nodeRoot.Name) ? nodeRoot.NodeType.ToString() + " node": nodeRoot.Name);

            DrawToChildCurve(nodeRoot);
        }
        EndWindows();

        // repaint
        Repaint();
    }

    void DrawMainMenu()
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
            if (asset)
            {
                if(GUI.Button(new Rect(220, 10, 100, 20), "Load"))
                {
                    assetName = asset.name;
                    nodeRootList = asset.ReturnNodeList(asset.NodeValue);
                }
            }
        }
    }

    void DrawNodeWindow(int id)
    {
        NodeValue nodeRoot = nodeRootList[id];
        nodeRoot.ShowName = GUI.Toggle(new Rect(1, 2, 10, 20), nodeRoot.ShowName, "", EditorStyles.miniButton);
        if (nodeRoot.ShowName)
        {
            nodeRoot.Name = GUILayout.TextField(nodeRoot.Name, 15);
        }
        nodeRoot.NodeType = (NodeType)EditorGUILayout.Popup((int)nodeRoot.NodeType, Enum.GetValues(typeof(NodeType)).Cast<NodeType>().Select(x => x.ToString()).ToArray());

        nodeRoot.Action = nodeRoot.NodeType == NodeType.Action ?
                          (Character.Behaviour.Action)EditorGUILayout.ObjectField(nodeRoot.Action, typeof(Character.Behaviour.Action)) :
                          null;
        // The window that can be dragged
        GUI.DragWindow();
    }

    // Get the node where the mouse is
    private NodeValue GetMouseInNode(out int index)
    {
        index = 0;
        NodeValue selectRoot = null;
        for (int i = 0; i < nodeRootList.Count; i++)
        {
            NodeValue nodeRoot = nodeRootList[i];
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
        NodeValue nodeSelect = new NodeValue();
        nodeSelect.WindowRect = new Rect(mousePosition.x, mousePosition.y, 120, 100);
        nodeRootList.Add(nodeSelect);
        nodeSelect.IsRootNode = nodeRootList.Count == 1;
    }

    // Connect child nodes
    private void MakeTransition()
    {
        makeTransitionMode = true;
    }

    // delete node
    private void DeleteNode()
    {
        int selectIndex = 0;
        selectNode = GetMouseInNode(out selectIndex);
        if (selectNode != null)
        {
            nodeRootList[selectIndex].Release();
            nodeRootList.Remove(selectNode);
            nodeRootList.ForEach((a) => a.IsRootNode = nodeRootList.Count == 1);
        }
    }

    /// <summary>
    ///  Draw lines from the node to all child nodes every frame
    /// </summary>
    /// <param name="nodeRoot"></param>
    private void DrawToChildCurve(NodeValue nodeRoot)
    {
        for (int i = nodeRoot.ChildNodeList.Count - 1; i >= 0; --i)
        {
            NodeValue childNode = nodeRoot.ChildNodeList[i];
            // delete invalid nodes
            if (childNode == null || childNode.IsRelease)
            {
                nodeRoot.ChildNodeList.RemoveAt(i);
                continue;
            }
            DrawNodeCurve(nodeRoot.WindowRect, childNode.WindowRect);
        }
    }

    // draw line
    public static void DrawNodeCurve(Rect start, Rect end)
    {
        Vector3 startPos = new Vector3(start.x + start.width / 2, start.y + start.height, 0);
        Vector3 endPos = new Vector3(end.x + end.width / 2, end.y, 0);

        Handles.DrawLine(startPos, endPos);
    }
}