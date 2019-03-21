using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OverworldCameraFollower : MonoBehaviour {

    Camera cam;

    //[Range(0.0f, 1.0f)]
    public float percent, distance, heightOffset;
    float time;
    [SerializeField]
    Transform farPosition, target;
    Vector3 velocity, v2;
    float deltaY, camDistance;

    public float timeSpan;
    float startTime;
    float y;

    float lastY;

    void Start()
    {
        cam = transform.GetChild(0).GetComponent<Camera>();
        camDistance = Vector3.Distance(farPosition.localPosition, Vector3.zero);

        lastY = target.position.y;
    }
    void FixedUpdate()
    {
        float playerY = target.transform.position.y;
        Vector3 targetXZ = new Vector3(target.transform.position.x, 0, target.transform.position.z);
        Vector3 transformXZ = new Vector3(transform.position.x, 0, transform.position.z);

        if (target.GetComponent<GroundCheck>().grounded)
        {
            lastY = playerY;
        }
        if (playerY < lastY)
            lastY = playerY;

        Vector3 targetPosition = Vector3.LerpUnclamped(Vector3.zero, farPosition.localPosition, distance / camDistance);
        cam.transform.localPosition = Vector3.Lerp(cam.transform.localPosition, targetPosition + Vector3.up*heightOffset, 0.1f);

        transform.position = Vector3.Lerp(transform.position, targetXZ + lastY * Vector3.up, 0.075f);
        //transform.rotation = target.rotation;
        transform.localEulerAngles += -Joysticks.RStick.StepInput.x * Vector3.up;
        distance += -Joysticks.RStick.StepInput.z* Time.fixedDeltaTime*10;
    }
}
