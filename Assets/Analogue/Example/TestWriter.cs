using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Analogue;
public class TestWriter : MonoBehaviour {

    public AnalogueController controller;

    //[SerializeField]int selection;
    void Awake()
    {

        Dictionary<int, Analogue_Node> nodeList = new Dictionary<int, Analogue_Node>();
        Analogue_Node node = AnalogueCreation.NewNode(NodeType.Dialogue);
        node.dialogue = new List<string>(new string[]{ "Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed do eiusmod tempor incididunt ut labore et dolore magna aliqua.",
                                                        "Ut enim ad minim veniam, quis nostrud exercitation ullamco laboris nisi ut aliquip ex ea commodo consequat.",
                                                        "Duis aute irure dolor in reprehenderit in voluptate velit esse cillum dolore eu fugiat nulla pariatur."});
        nodeList.Add(node.ID, node);
        print(node.ID);
        controller.currentNode = node.ID;
        node = AnalogueCreation.NewNode(NodeType.Choice);
        node.dialogue = new List<string>(new string[] { "Yes",
                                        "Sure",
                                        "Why not?" });

        nodeList.Add(node.ID, node);

        node = AnalogueCreation.NewNode(NodeType.Choice);
        node.dialogue = new List<string>(new string[] { "Erm...",
                                        "Uh...",
                                        "Hmph..." });


        nodeList.Add(node.ID, node);

        node = AnalogueCreation.NewNode(NodeType.Dialogue);
        nodeList.Add(node.ID, node);
        
        Analogue_DB.selectedSet.dialogueData = nodeList;
    }
	
	void Update ()
    {
        
        bool isChoice = controller.dialogue.dialogueData[controller.currentNode] is Analogue_Choice;
        if (Input.GetKeyDown(KeyCode.Space))
        {
            if (controller.dialogue.dialogueData[controller.currentNode] is Analogue_Choice)
            {
                    controller.currentNode = controller.dialogue.dialogueData[controller.currentNode].connections[controller.selection];
            }

            
        }
		if (Input.GetKeyDown(KeyCode.UpArrow| KeyCode.W))
        {
            if (isChoice)
                Wrap(controller.selection - 1, 0, controller.dialogue.dialogueData[controller.currentNode].dialogue.Count-1);

        }
        else if (Input.GetKey(KeyCode.DownArrow| KeyCode.S))
        {
            if(isChoice)
                Wrap(controller.selection + 1, 0, controller.dialogue.dialogueData[controller.currentNode].dialogue.Count-1);
        }
    }
    int Wrap(int x, int min, int max)
    {//x,l,h
        max = max - min + 1; x = (x - min) % max + min; if (x < min) x += max;
        return x;
    }
}
