using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    public bool grounded, goodAngle, goodHeight, jumping;
    public float maxStepHeight, tolerance, maxAngle;
    BoxCollider box;
    //RaycastHit[,] hits = new RaycastHit[3, 3];
    RaycastHit[] hits = new RaycastHit[9];
    bool[] rayHits = new bool[9];

    bool groundedLastFrame = false;
    float lastFrameHeight;

    [SerializeField]
    float offset;
    float boxX, boxZ;

    void Start () {
        box = GetComponent<BoxCollider>();
        //(0.5f * box.size.z);
        
        //box.size = new Vector3(0.79f,1.5f,0.79f);
    }
	
	void FixedUpdate ()
    {
        boxX = 0.5f * box.size.x + offset;
        boxZ = 0.5f * box.size.z + offset;
        /*
        0,0 | 1,0 | 2,0
        ---------------
        0,1 | 1,1 | 2,1
        ---------------
        0,2 | 1,2 | 2,2
        */

        rayHits[0] = Physics.Raycast(transform.position + transform.TransformDirection(new Vector3(0, maxStepHeight, boxZ)), Vector3.down, out hits[0]);//[1, 0]);//Top
        rayHits[1] = Physics.Raycast(transform.position + transform.TransformDirection(new Vector3(0, maxStepHeight, -boxZ)), Vector3.down, out hits[1]);//[1, 2]);//Bot
        rayHits[2] = Physics.Raycast(transform.position + transform.TransformDirection(new Vector3(-boxX, maxStepHeight, 0)), Vector3.down, out hits[2]);//[0, 1]);//Left
        rayHits[3] = Physics.Raycast(transform.position + transform.TransformDirection(new Vector3(boxX, maxStepHeight, 0)), Vector3.down, out hits[3]);//[2, 1]);//Right

        rayHits[4] = Physics.Raycast(transform.position + transform.TransformDirection(new Vector3(0, maxStepHeight, 0)), Vector3.down, out hits[4]);//[1, 1]);//Mid

        rayHits[5] = Physics.Raycast(transform.position + transform.TransformDirection(new Vector3(-boxX, maxStepHeight, boxZ)), Vector3.down, out hits[5]);//[0, 0]);//TopLeft
        rayHits[6] = Physics.Raycast(transform.position + transform.TransformDirection(new Vector3(boxX, maxStepHeight, boxZ)), Vector3.down, out hits[6]);//[2, 0]);//TopRight
        rayHits[7] = Physics.Raycast(transform.position + transform.TransformDirection(new Vector3(-boxX, maxStepHeight, -boxZ)), Vector3.down, out hits[7]);//[0, 2]);//BotLeft
        rayHits[8] = Physics.Raycast(transform.position + transform.TransformDirection(new Vector3(boxX, maxStepHeight, -boxZ)), Vector3.down, out hits[8]);//[2, 2]);//BotRight


        int i = 0;
        grounded = false;
        float h = Mathf.Infinity; //the farthest distance

        goodAngle = false;
        goodHeight = false;

        foreach (RaycastHit hit in hits)
        {
            float d = hit.distance - maxStepHeight;
            if (!rayHits[i])
                d = Mathf.Infinity;
            else if (d < h)
                h = d;

            if (Vector3.Angle(hit.normal, Vector3.up) <= maxAngle)
                goodAngle = true;

            if (d < tolerance)
                goodHeight = true;

            if (goodAngle && goodHeight)
                grounded = true;

            //print(d + " " + i);
            //print(Vector3.Angle(hit.normal, Vector3.up))
            //print (i + ", " + h);
            Debug.DrawRay(hit.point, Vector3.up,Color.red);
            i++;
        }
        if (!jumping && goodAngle && Mathf.Abs(h) <= maxStepHeight + tolerance)
            if (grounded)
                transform.position -= (h - 0.0001f) * Vector3.up;
            else if (!grounded && groundedLastFrame)
            {
                transform.position -= Vector3.up * h;
                grounded = true;
            }
        lastFrameHeight = h;
        groundedLastFrame = grounded;
        //print(h + ", " + h2);
        //int[] falseIndexes = BoolCheck.WhichAreFalse(rayHits);
        /*if (falseIndexes.Length == 9)//!BoolCheck.AnyTrue(rayHits))
            grounded = false;
        else
            foreach(int I in falseIndexes)
            {

            }*/
    }
}
