using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class _4WaySpriteRotation : MonoBehaviour
{
    float v;
    public float targetAngle;
    [SerializeField]
    public float currentAngle;// {get; private set;}
    [Range(0.0f, 1.0f)]
    public float t;
    Billboarder billboarder;
    void Awake()
    {
        billboarder = GetComponentInChildren<Billboarder>();
    }
    //angles that the model/sprite will "face"
    //↖ ↗
    //↙ ↘
    protected virtual void FixedUpdate()
    {
        //Mathf.LerpAngle()
        targetAngle = Mathf.Repeat(targetAngle, 360);
        float targetA = targetAngle;
        //if ()
        //currentAngle = Mathf.LerpAngle(currentAngle, targetA, t);

        currentAngle = Mathf.SmoothDampAngle(currentAngle, targetA, ref v, t);
        currentAngle = Mathf.Repeat(currentAngle, 360);

        transform.localEulerAngles = currentAngle * 2 * Vector3.up;

        //transform.localRotation = Quaternion.Slerp(Quaternion.Euler(transform.localEulerAngles), Quaternion.Euler(angle * transform.up), 0.2f);

        #region scaling
        float totaZScale = billboarder.zScale;// * billboarder.camSide;
        if (currentAngle > 0 && currentAngle < 90)        //backleft to topleft
        {
            billboarder.transform.localScale = new Vector3(totaZScale * billboarder.camSide, 1, totaZScale);
        }
        else if (currentAngle > 90 && currentAngle < 180) //topleft to topright
        {
            billboarder.transform.localScale = new Vector3(-1, 1, totaZScale);
        }
        else if (currentAngle > 180 && currentAngle < 270)//topright to backright
        {
            billboarder.transform.localScale = new Vector3(-totaZScale * billboarder.camSide, 1, totaZScale);
        }
        else if (currentAngle > 270 && currentAngle < 360)//backright to backleft
        {
            billboarder.transform.localScale = new Vector3(1, 1, totaZScale);
        }
        #endregion
    }
}
