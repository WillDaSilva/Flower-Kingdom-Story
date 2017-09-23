using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PendulumMotion : MonoBehaviour {
    public ClockScript clock;
    public float frequency, magnitude;
    void Start () {
		
	}
	
	void Update () {
        transform.localEulerAngles = new Vector3(0, 0, Mathf.Sin(clock.scaledTime * frequency * Mathf.Deg2Rad * 360)) * magnitude;

    }
    
}
