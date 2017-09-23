using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollower : MonoBehaviour {
    Camera cam;
    //[Range(0.0f, 1.0f)]
    public float percent, distance, heightOffset;
    float time;
    [SerializeField]
    Transform farPosition, targetTransform;
    Vector3 velocity, v2;
    float deltaY, camDistance;

    public float timeSpan;
    float startTime;
    float y;
	void Awake () {
        cam = transform.GetChild(0).GetComponent<Camera>();
        camDistance = Vector3.Distance(farPosition.localPosition, Vector3.zero);

    }
	void FixedUpdate ()
    {
        //time = Time.fixedTime-startTime;
        y = (targetTransform.position.y) / 3 - heightOffset;
        deltaY = targetTransform.transform.position.y;

        Vector3 groundPos = new Vector3(transform.position.x, heightOffset, transform.position.z);
        transform.position = Vector3.SmoothDamp(groundPos, targetTransform.position + heightOffset * Vector3.up, ref v2, 0.25f) + y * Vector3.up;

        Vector3 camPos = Vector3.LerpUnclamped(Vector3.zero, farPosition.localPosition, (deltaY / camDistance)+distance) + heightOffset * Vector3.up; ;
        cam.transform.localPosition = Vector3.SmoothDamp(cam.transform.localPosition, camPos, ref velocity, 0.0625f);//125f);
        if (cam.orthographic)
            cam.orthographicSize = deltaY + 5;

    }
}
