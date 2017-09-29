using UnityEngine;
using System.Collections;

public class Billboarder : MonoBehaviour {
    [SerializeField]
    float angleBetween;
    [SerializeField]
    float angleBetween2;
    [SerializeField]
    public float zScale;
    public float frontBack;
    public float camSide;
    float camAngle;
	float thisAngle;
	float parentAngle;

    new Camera camera;

    public bool localSpace;

    public bool turn;
    float turnSpd;
    public float direction;

    void Start()
    {
        camera = Camera.main;
    }
	void UpdateCamera ()
    {
	    
	}
    
    void FixedUpdate() {
        direction = Mathf.Repeat(direction, 360);
        camAngle = camera.transform.eulerAngles.y;
        parentAngle = transform.parent.eulerAngles.y;
        
        angleBetween = Mathf.Abs(Mathf.DeltaAngle(camAngle, parentAngle));

        angleBetween2 = Math.PointsToAngle(camera.transform.position, transform.position);
        
        if (angleBetween<90)
            camSide = 1;
        else camSide = -1;

        float zSA = Mathf.Repeat(angleBetween2 + transform.eulerAngles.y, 360) - 180;
        if (zSA > 0 && zSA < 180)
        {
            zScale = -1;
        }
        if (zSA < 0 && zSA > -180)
        {
            zScale = 1;
        }
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, zScale);
        /*if (turn)
        {
            transform.localRotation = Quaternion.Slerp(transform.localRotation, Quaternion.Euler(new Vector3(transform.localRotation.x, direction, transform.localRotation.z)), Time.fixedDeltaTime * 9);//0.15f
        }
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y, zScale);*/
    }
}
