using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _4WaySpriteRotation : MonoBehaviour
{
    public float targetAngle;
    [SerializeField]
    public float currentAngle;// {get; private set;}
    [Range(0.0f, 1.0f)]
    public float t;
    void Start()
    {

    }
    //angles that the model/sprite will "face"
    //↖ ↗
    //↙ ↘
    void FixedUpdate()
    {
        //Mathf.LerpAngle()
        targetAngle = Mathf.Repeat(targetAngle, 360);
        //if ()
        currentAngle = Mathf.LerpAngle(currentAngle, targetAngle, t);
        currentAngle = Mathf.Repeat(currentAngle, 360);

        transform.localEulerAngles = currentAngle * 2 * Vector3.up;

        //transform.localRotation = Quaternion.Slerp(Quaternion.Euler(transform.localEulerAngles), Quaternion.Euler(angle * transform.up), 0.2f);
    }
}
