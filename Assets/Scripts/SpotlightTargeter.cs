using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpotlightTargeter : MonoBehaviour {
    public Transform target;
    new Light light;
	// Use this for initialization
	void Start ()
    {
        light = GetComponent<Light>();//InChildren<Light>();
        //target = transform.GetChild(1);
	}

    // Update is called once per frame
    void Update()
    {
        /*Quaternion rot = Quaternion.LookRotation(target.position, Vector3.up);
        light.transform.rotation = Quaternion.Lerp(light.transform.rotation, rot, 0.25f);*/

        Quaternion targetRotation = Quaternion.LookRotation(target.transform.position - transform.position + Vector3.up);
        if (target.position.x > 13.5f)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10 * Time.deltaTime);
        }
        else
        {
            targetRotation = Quaternion.Euler(2, 0, 0);
            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, 10 * Time.deltaTime);
        }
    }
}
