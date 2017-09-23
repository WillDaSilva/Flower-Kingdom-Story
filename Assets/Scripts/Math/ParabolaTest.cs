using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParabolaTest : MonoBehaviour {
    public int iterations;
    public float density;
    public float d, g, x, hI, hM;
    LineRenderer[] lr = new LineRenderer[2];

    

    void Start () {
        lr[0] = GetComponent<LineRenderer>();
        lr[1] = transform.GetChild(0).GetComponent<LineRenderer>();
    }
	
	void FixedUpdate () {
        List<Vector3> ts = new List<Vector3>();
        List<Vector3> ts2 = new List<Vector3>();
        for (int i = 0; i<iterations; i++)
        {
            ts.Add(transform.position + new Vector3(d * i, Parabola.Calculate(hI, hM, g, i * x)));
            ts2.Add(transform.position + new Vector3(d * i, Parabola.CalculateSlope(hI, hM, g, i * x)));
        }

        lr[0].SetPositions(ts.ToArray());
        lr[1].SetPositions(ts2.ToArray());
        /*//Time.fixedTime
        if(Time.fixedTime>1)
            transform.position = new Vector3((Time.fixedTime-1) * 10, Parabola.Calculate(0,10, -30, Time.fixedTime-1),transform.position.z);
        //print(Parabola.CalculateHitTime(10, 5, -30));
        if (Parabola.CalculateHitTime(0,10, 5, -30) < Time.fixedTime - 1)
            Time.timeScale = 0;*/
    }
}
