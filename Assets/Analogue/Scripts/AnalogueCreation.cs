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

            switch (type)
            {
                default:
                case NodeType.Dialogue:
                    node = new Analogue_Dialogue();
                    break;
                case NodeType.Choice:
                    node = new Analogue_Choice();
                    break;
                case NodeType.Bool:
                    node = new Analogue_Bool();
                    break;
                case NodeType.Script:
                    node = new Analogue_Script();
                    break;
            }

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