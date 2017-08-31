using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Analogue
{
    public class AnalogueCreation
    {
        public static Analogue_Node NewNode(NodeType type)
        {
            Analogue_Node node;

            if (type == NodeType.Dialogue)
                node = new Analogue_Dialogue();
            else if (type == NodeType.Choice)
                node = new Analogue_Choice();
            else if (type == NodeType.Bool)
                node = new Analogue_Bool();
            else// if (type == NodeType.Script) // is 'else' because 'else if' throws a compiler error;
                node = new Analogue_Script(); //remove first '//' above when adding more nodes and else for final additional node
            int generatedID;
            do
            { //continues to attempt to generate unique ID until new ID is generated
                generatedID = Random.Range(0, int.MaxValue);
            } while (Analogue_DB.selectedSet.dialogueData.ContainsKey(generatedID));
            node.ID = generatedID;
            return node;
        }
    }
}