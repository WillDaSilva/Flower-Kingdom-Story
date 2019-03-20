using System;
using System.Collections.Generic;
using UnityEngine;
namespace Analogue
{
    public class Analogue_Set : MonoBehaviour
    {
        public Analogue_Set(int setID, Dictionary<int,Analogue_Node> nodes, int startNode, string language, string[] entities, Dictionary<string, object> extraData)
        {
            foreach (Analogue_Node node in nodes.Values)
                dialogueData.Add(node.ID, node);
            this.startNode = startNode;
            startOverride = -1;
            //this.entities = 
        }
        public Analogue_Set()
        {

        }
        public int setID;
        public string summary;
        public string dialogueDirectory;// { get; private set; }
        public string translationDirectory;// { get; private set; }
        public string currentLanguage;// { get; private set; }
        [HideInInspector]
        public string itemName;
        [HideInInspector]
        public string[] entities;
        public Dictionary<int, Analogue_Node> dialogueData = new Dictionary<int, Analogue_Node>();
        public Dictionary<string, object> extraData = new Dictionary<string, object>();
        [HideInInspector]
        public int startNode;
        public int startOverride = -1;
        void OverrideStartNode(int id)
        {
            startOverride = id;
        }
    }
}
