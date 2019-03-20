/*using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using System.IO;

namespace Analogue.DialogueEditor
{
    public class AnalogueEditor : EditorWindow
    {
        private GUIStyle nodeStyle;


        List<Node> nodes;
        static void OpenWindow()
        {
            AnalogueEditor window = GetWindow<AnalogueEditor>();
            window.titleContent = new GUIContent("Analogue: [Dialogue Set Name]");
        }
        void OnEnable()
        {
            nodeStyle = new GUIStyle();
            nodeStyle.normal.background = EditorGUIUtility.Load("builtin skins/darkskin/images/node1.png") as Texture2D;
            nodeStyle.border = new RectOffset(12, 12, 12, 12);
        }

        private void OnGUI()
        {
            DrawNodes();

            ProcessEvents(Event.current);

            if (GUI.changed)
                Repaint();
        }

        void DrawNodes()
        {
            foreach (Node node in nodes)
                node.Draw();
        }
        void ProcessEvents(Event e)
        {
            switch (e.type)
            {
                case EventType.MouseDown:
                    if (e.button == 1)
                    {
                        ProcessContextMenu(e.mousePosition);
                    }
                    break;
            }
        }
        private void ProcessContextMenu(Vector2 mousePosition)
        {
            GenericMenu genericMenu = new GenericMenu();
            genericMenu.AddItem(new GUIContent("Add Node"), false, () => AddNode(mousePosition));
            genericMenu.ShowAsContext();
        }
        private void AddNode(Vector2 mousePosition)
        {
            if (nodes == null)
            {
                nodes = new List<Node>();
            }

            nodes.Add(new Node(mousePosition, 200, 50, nodeStyle));
        }
        
        string mainDirectory = "Resources/Analogue/";
    }
    public class Node
    {
        public Rect rect;
        public string ID;

        public GUIStyle style;

        public Node(Vector2 position, float width, float height, GUIStyle nodeStyle)
        {
            rect = new Rect(position.x, position.y, width, height);
            style = nodeStyle;
        }

        public void Drag(Vector2 delta)
        {
            rect.position += delta;
        }

        public void Draw()
        {
            GUI.Box(rect, ID, style);
        }

        public bool ProcessEvents(Event e)
        {
            return false;
        }
    }
}
*/