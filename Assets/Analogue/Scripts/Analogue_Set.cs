using System.Collections.Generic;
using UnityEngine;
namespace Analogue
{
    public class Analogue_Set : MonoBehaviour
    {
        public string dialogueDirectory;
        public string itemName;
        [HideInInspector]
        public List<string> entities;
        public Dictionary<int, Analogue_Node> dialogueData = new Dictionary<int, Analogue_Node>();
        [HideInInspector]
        public int startNode;
        public int startOverride;
        void OverrideStartNode(int id)
        {
            startOverride = id;
        }
    }
}
