using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Events;
using System;

namespace Analogue
{
    public enum NodeType { Dialogue, Choice, Bool, Script }
    [Serializable]
    public class Analogue_Node
    {
        public Analogue_Node(int ID)
        {

        }
        public Analogue_Node()
        {

        }
        public int ID;
        public string summary;
        public List<string> dialogue= new List<string>();
        public List<int> connections = new List<int>();
        public Dictionary<string, object> extraData;
    }
    [Serializable]
    public class Analogue_Dialogue : Analogue_Node
    {
        public string entity;

        public Analogue_Dialogue(int ID, string entity, List<string> dialogue, int connection, Dictionary<string, object> extraData)// : base(ID)
        {
            this.ID = ID;
            this.entity = entity;
            this.dialogue = dialogue;
            connections.Add(connection);
            this.extraData = extraData;
        }
        public Analogue_Dialogue(int ID, List<string> dialogue, int connection, Dictionary<string, object> extraData)// : base(ID)
        {
            this.ID = ID;
            this.dialogue = dialogue;
            connections.Add(connection);
            this.extraData = extraData;
        }
        public Analogue_Dialogue()
        {
            
        }
        public Analogue_Dialogue(int ID)
        {
            this.ID = ID;
        }
    }
    [Serializable]
    public class Analogue_Choice: Analogue_Node
    {
        public Analogue_Choice(int ID, List<string> choices, List<int> connections, int defaultSelection, Dictionary<string, object> extraData)
        {
            this.ID = ID;
            dialogue = choices;
            this.connections = connections;
            this.extraData = extraData;
            this.defaultSelection = defaultSelection;
        }
        public Analogue_Choice(int ID, List<string> choices, List<string> dialogue, List<int> connections, int defaultSelection, Dictionary<string, object> extraData)
        {
            this.ID = ID;
            this.dialogue = choices;
            this.connections = connections;
            this.extraData = extraData;
            this.defaultSelection = defaultSelection;
        }
        public Analogue_Choice(int ID)
        {
            this.ID = ID;
        }
        public Analogue_Choice()
        {

        }

        public int defaultSelection;
    }
    [Serializable]
    public class Analogue_Bool : Analogue_Node
    {
        public Analogue_Bool(int ID, List<Func<bool>> boolFuncs, List<int> connections, int failNode, Dictionary<string, object> extraData)
        {
            this.ID = ID;
            this.connections = connections;
            boolMethods = boolFuncs;
            this.extraData = extraData;
            this.failNode = failNode;
        }
        public Analogue_Bool(int ID)
        {
            this.ID = ID;
        }
        public Analogue_Bool()
        {

        }
        public List<Func<bool>> boolMethods;
        public bool waitUntilTrue;
        public int failNode;
        public int Evaluate()
        {
            int i = 0;
            foreach (Func<bool> b in boolMethods)
            {
                if (b.Invoke())
                    return connections[i];
                i++;
            }
            Debug.Log("No booleans in " + GetType() + ", ID " + ID + "returned true");
            return failNode;
        }
    }
    [Serializable]
    public class Analogue_Script : Analogue_Node
    {
        public Analogue_Script(int ID, List<UnityEvent> unityEvents, int connection, Dictionary<string, object> extraData)
        {
            this.ID = ID;
            this.unityEvents = unityEvents;
            connections = new List<int>() { connection };
            this.extraData = extraData;
        }
        public Analogue_Script()
        {

        }
        public List<UnityEvent> unityEvents;
        public void RunEvents()
        {
            foreach (UnityEvent unityEvent in unityEvents)
            {
                unityEvent.Invoke();
            }
        }
    }
    public class Analogue_Overrider : Analogue_Node
    {
        public Analogue_Overrider(int ID, int overrideID, int connection, Dictionary<string, object> extraData)
        {
            this.ID = ID;
            this.overrideID = overrideID;
            connections = new List<int>() { connection };
            this.extraData = extraData;
        }
        public Analogue_Overrider()
        {

        }
        public int overrideID;
    }
}