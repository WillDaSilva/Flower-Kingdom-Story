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
    Billboarder billboarder;
    void Awake()
    {
        billboarder = GetComponent<Billboarder>();
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

        #region scaling
        float totaZScale = billboarder.zScale;// * billboarder.camSide;
        if (currentAngle > 0 && currentAngle < 90)        //backright to backleft
        {
            transform.localScale = new Vector3(billboarder.camSide, 1, totaZScale);
        }
        else if (currentAngle > 90 && currentAngle < 180) //backleft to topleft
        {
            transform.localScale = new Vector3(-totaZScale, 1, totaZScale);
        }
        else if (currentAngle > 180 && currentAngle < 270)//topleft to topright
        {
            transform.localScale = new Vector3(-billboarder.camSide, 1, totaZScale);
        }
        else if (currentAngle > 270 && currentAngle < 720)//topright to backright
        {
            transform.localScale = new Vector3(totaZScale, 1, totaZScale);
        }
        #endregion
    }
}
