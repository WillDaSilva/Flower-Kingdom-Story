using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using System;
using UnityEngine.Events;

namespace Analogue
{
    public class AnalogueController: MonoBehaviour
    {
        public List<GameObject> dialogueRelated;
        public Analogue_Set dialogue;
        //Dictionary<int, Analogue_Node> Data;
        public int currentNode, currentDialogue, selection;
        public Analogue_Node currentNode_ref { get; private set; }
        public List<Analogue_Node> inspectorNodeDisplay = new List<Analogue_Node>();
        void Start()
        {
            /*foreach (Analogue_Node node in dialogue.dialogueData.Values)
            {
                inspectorNodeDisplay.Add(node);
            }*/
        }
        /*public void LoadSet(Analogue_Set setToLoad)
        {
            dialogue = setToLoad;
            SetNode(dialogue.startNode);
            SendDialogueLoad();
        }*/
        public void StartDialogue(Analogue_Set setToLoad)
        {
            dialogue = setToLoad;
            DisplayDialogueLoadDebug();
            if (dialogue.startOverride < 0)
                SetNode(dialogue.startNode);
            else if (!dialogue.dialogueData.ContainsKey(dialogue.startOverride))
            {
                Debug.LogError("ID not valid. Loading default start node");
                SetNode(dialogue.startNode);
            }
            else SetNode(dialogue.startOverride);
            SendDialogueLoad();
            //DisplayDialogueDebug();
        }
        public void SetNode(int nodeID)
        {
            if (nodeID == -1) //(dialogue.dialogueData[nodeID].ID == -1) Wait, Why did I do it liek this?
                EndDialogue();
            else if (!dialogue.dialogueData.ContainsKey(nodeID))//[nodeID] == null)
            {
                Debug.LogError("Node Does Not Exist. Terminating Dialogue.");
                EndDialogue();
            }
            else
            {
                currentNode = nodeID;
                currentNode_ref = dialogue.dialogueData[currentNode];
                OnNodeChange();
            }
        }
        void OnNodeChange()
        {
            DisplayDialogueDebug();
            SendNodeChanged();

            if (currentNode_ref is Analogue_Script)
                CheckScriptNode();
            else if (currentNode_ref is Analogue_Bool)
                CheckBoolNode();
            else if (currentNode_ref is Analogue_Choice)
                OnChoiceLoad();
            else if (currentNode_ref is Analogue_Overrider)
                CheckOverrider();

        }
        #region OnNodeLoads
        void OnChoiceLoad()
        {
            selection = ((Analogue_Choice)currentNode_ref).defaultSelection;
        }
        #endregion
        #region All Node Checks
        public void Next()
        {
            if (dialogue == null)
            {
                Debug.Log("DialogueSet not set!");
                return;
            }
            else if (currentNode_ref == null)
            {
                Debug.Log("DialogueNode not set!");
                return;
            }
            else if (currentNode <= -1)
            {
                EndDialogue();
                return;
            }
            CheckNode();
        }

        void OnDialogueLoad()
        {
            if (currentDialogue < currentNode_ref.dialogue.Count - 1)
            {
                currentDialogue++;
                OnNodeChange();
            }
            else
            {
                currentDialogue = 0;

                if (currentNode_ref.connections != null)
                {
                    //currentNode_ref = dialogue.dialogueData[currentNode];
                    if (currentNode == -1 || currentNode_ref.connections[0] == -1)
                    {
                        EndDialogue();
                    }
                    else SetNode(currentNode_ref.connections[0]);
                }
                else
                {
                    currentNode_ref = new Analogue_Dialogue(1, "console", new List<string>() {
                        "An error has occurred:\nNo Dialogue ID found. Terminating Dialogue.\nCheck node ID " + currentNode_ref.ID + " with dialogue:\n" + currentNode_ref.dialogue[0] + "\nSummary: " + currentNode_ref.summary}, -1, null);
                    EndDialogue();
                }
            }
        }
        public void Select(int selectedIndex)
        {
            if (selection > currentNode_ref.connections.Count - 1)
            {
                Debug.LogAssertion("Error: Selection Out of range");
                EndDialogue();
                return;
            }
            if (currentNode_ref.connections[selectedIndex] == -1)
            {
                EndDialogue();
                return;
            }
            SetNode(currentNode_ref.connections[selectedIndex]);
            SendOnChoiceSelected();
        }
        void CheckBoolNode()
        {
            int i = 0;
            foreach (Func<bool> method in ((Analogue_Bool)dialogue.dialogueData[currentNode]).boolMethods)
            {
                if (method.Invoke()) //replace with reflection, script running;
                {
                    SetNode(currentNode_ref.connections[i]);
                    return;
                }
                i++;
            }
            SetNode(((Analogue_Bool)currentNode_ref).failNode);
        }
        void CheckScriptNode()
        {
            ((Analogue_Script)currentNode_ref).RunEvents();
            SetNode(currentNode_ref.connections[0]);
        }

        void CheckOverrider()
        {
            dialogue.startOverride = ((Analogue_Overrider)currentNode_ref).overrideID;
            SetNode(currentNode_ref.connections[0]);
        }
        #endregion

        public void CheckNode()
        {
            if (currentNode == -1)
                EndDialogue();
            else if (dialogue.dialogueData[currentNode] is Analogue_Dialogue)
                OnDialogueLoad();
            else if (dialogue.dialogueData[currentNode] is Analogue_Choice)
                OnChoiceLoad();
            else if (dialogue.dialogueData[currentNode] is Analogue_Bool)
                CheckBoolNode();
            else if (dialogue.dialogueData[currentNode] is Analogue_Script)
                CheckScriptNode();
            else if (dialogue.dialogueData[currentNode] is Analogue_Overrider)
                CheckOverrider();

        }
        public void EndDialogue()
        {
            currentNode = 0;
            currentDialogue = 0;
            selection = 0;
            dialogue = null;
            currentNode_ref = null;
            Debug.LogWarning("Ended Dialogue ");
            SendDialogueEnded();
            SendOnSetEnd();
        }
        void DisplayDialogueLoadDebug()
        {
            string debugString = "Loaded Dialogue set with ID " + dialogue.setID + Environment.NewLine + "Summary: " + dialogue.summary;
            Debug.LogWarning(debugString);
        }
        void DisplayDialogueDebug()
        {
            string debugString;
            //string debugString = "Node: " + currentNode + " D Index: " + currentDialogue + Environment.NewLine + dialogue.dialogueData[currentNode].dialogue[currentDialogue] + Environment.NewLine;
            /*if (dialogue.startNode == currentNode_ref.ID)
            {
                debugString = "Loaded Dialogue set with ID " + dialogue.setID + Environment.NewLine + "Summary: " + dialogue.summary;
                Debug.LogWarning(debugString);
            }*/
                debugString = "Incremented to ";
            debugString += currentNode_ref.GetType() + " with ID " + currentNode_ref.ID;
            if (!string.IsNullOrEmpty(currentNode_ref.summary))
                debugString += Environment.NewLine + "Summary: " + currentNode_ref.summary;


            if (currentNode_ref is Analogue_Dialogue)
            {
                debugString += " and dialogue index " + currentDialogue + "/" + (currentNode_ref.dialogue.Count - 1)
                    + Environment.NewLine+ "Dialogue: " + currentNode_ref.dialogue[currentDialogue];
            }

            debugString += Environment.NewLine;

            if (currentNode_ref is Analogue_Choice)
            {
                debugString += "Choices:  ";// + Environment.NewLine;
                int choiceIndex = 0;
                foreach (string choice in currentNode_ref.dialogue)
                {
                    debugString += choice;
                    int x = Mathf.Max(15 - choice.Length, 0);
                    for (int i = 0; i < x; i++)
                        debugString += " ";
                    debugString += currentNode_ref.connections[choiceIndex] + ", ";
                    choiceIndex++; 
                }
            }
            //else if(currentNode_ref is Analogue_Script)
                //debugString +=

            Debug.Log(debugString);
        }
        #region Message Sending
        void SendOnSetLoad()
        {
            SendMessageToMultiple("OnSetLoad");
        }
        void SendOnSetEnd()
        {
            SendMessageToMultiple("OnSetEnd");
        }
        void SendNodeChanged()
        {
            SendMessageToMultiple("OnNodeUpdate");
        }
        void SendIsChoiceNode()
        {
            SendMessageToMultiple("OnChoiceUpdate");
        }
        void SendIsDialogueNode()
        {
            SendMessageToMultiple("OnDialogueUpdate");
        }
        void SendDialogueEnded()
        {
            SendMessageToMultiple("OnDialogueEnd");
        }
        void SendDialogueLoad()
        {
            SendMessageToMultiple("OnDialogueLoad");
        }
        void SendDialogueNext()
        {
            SendMessageToMultiple("OnDialogueNext");
        }
        void SendOnChoiceSelected()
        {
            SendMessageToMultiple("OnChoiceSelect");
        }

        void SendMessageToMultiple(string s)
        {
            foreach (GameObject go in dialogueRelated)
            {
                go.SendMessage(s);
            }
        }
        #endregion
        /*void DisplayChoiceDebug()
        {
            string s = "Choices: ";
            foreach (int i in dialogue.dialogueData[currentDialogue].connections)
            {
                s += dialogue.dialogueData[currentDialogue].dialogue + ": " + i + System.Environment.NewLine;
            }
            Debug.Log("Node: " + currentNode + " D Index: " + currentDialogue + Environment.NewLine + dialogue.dialogueData[currentNode].dialogue[currentDialogue]);
        }
        void CheckNodeType()
        {
            if (dialogue.dialogueData[currentNode] is Analogue_Dialogue)
                print("dialogue" + currentNode);
            else if (dialogue.dialogueData[currentNode] is Analogue_Choice)
                print("choice" + currentNode);
            else if (dialogue.dialogueData[currentNode] is Analogue_Bool)
                print("bool" + currentNode);
            else if (dialogue.dialogueData[currentNode] is Analogue_Script)
                print("Script" + currentNode);
        }*/
    }
}
