using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;

namespace Analogue
{
    public class AnalogueController: MonoBehaviour
    {
        public Analogue_Set dialogue;
        //Dictionary<int, Analogue_Node> Data;
        public int currentNode, currentDialogue, selection;

        void Start()
        {


        }
        #region All Node Checks
        void NextNode()
        {
            if (currentDialogue < dialogue.dialogueData[currentNode].dialogue.Count)
                currentDialogue++;
            else
            {
                currentDialogue = 0;
                currentNode = dialogue.dialogueData[currentNode].connections[0];
            }
                //return;
            //}
        }
        void Select(int selectedIndex)
        {
            currentNode = dialogue.dialogueData[currentNode].connections[selectedIndex];
        }
        void EvaluateBools()
        {
            int i = 0;
            foreach (Func<bool> method in ((Analogue_Bool)dialogue.dialogueData[currentNode]).boolMethods)
            {
                if (method.Invoke()) //replace with reflection, script running;
                {
                    currentNode = dialogue.dialogueData[currentNode].connections[i];
                    break;
                }

                else currentNode = ((Analogue_Bool)dialogue.dialogueData[currentNode]).failNode;
                i++;
            }
        }
        void RunMethods()
        {
            foreach (UnityEvent unityEvent in ((Analogue_Script)dialogue.dialogueData[currentNode]).methods)
            {
                unityEvent.Invoke();
            }
        }
        #endregion
        public void StartDialogue()
        {
            if (dialogue.startOverride < 0)
                currentNode = dialogue.startNode;
            else currentNode = dialogue.startOverride;
        }
        public void CheckNode()
        {
            if (dialogue.dialogueData[currentNode] is Analogue_Dialogue)
                NextNode();
            else if (dialogue.dialogueData[currentNode] is Analogue_Choice)
                return;
            else if (dialogue.dialogueData[currentNode] is Analogue_Bool)
                EvaluateBools();
            else if (dialogue.dialogueData[currentNode] is Analogue_Script)
                RunMethods();

            selection = ((Analogue_Choice)dialogue.dialogueData[currentNode]).defaultSelection;
        }
    }
}
