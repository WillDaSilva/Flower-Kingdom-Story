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
        public int ID;
        public List<string> dialogue= new List<string>();
        public List<int> connections = new List<int>();
        public SortedDictionary<string, object> extraData;
    }
    [Serializable]
    public class Analogue_Dialogue : Analogue_Node
    {
        public string entity;
    }
    [Serializable]
    public class Analogue_Choice: Analogue_Node
    {
        public int defaultSelection;
    }
    [Serializable]
    public class Analogue_Bool : Analogue_Node
    {
        public List<Func<bool>> boolMethods;
        public int failNode;
    }
    [Serializable]
    public class Analogue_Script : Analogue_Node
    {
        public List<UnityEvent> methods;
    }
}