using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ControllerDisplay : MonoBehaviour {

    public Image a, b, x, y, start, l, r,
            joy, c, d, z;
	void Start ()
    {
		
	}
	
	void Update ()
    {
        joy.transform.localPosition = new Vector3(Joysticks.LStick.CappedInput.x, Joysticks.LStick.CappedInput.z) * 13f;
        joy.transform.localScale = new Vector2(Mathf.Sqrt(1 - Joysticks.LStick.CappedInput.magnitude / 2), 1);
        Vector2 direction = joy.transform.position - joy.transform.parent.position;
        joy.transform.localRotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, Vector3.forward);
        //joy.transform.localRotation *= Quaternion.AngleAxis(Mathf.Sin(Joysticks.LStick.CappedInput.magnitude)*-40, Vector3.up);

        c.transform.localPosition = new Vector3(Joysticks.RStick.CappedInput.x, Joysticks.RStick.CappedInput.z) * 13f;
        c.transform.localScale = new Vector2(Mathf.Sqrt(1 - Joysticks.RStick.CappedInput.magnitude / 2), 1);
        direction = c.transform.position - c.transform.parent.position;
        c.transform.localRotation = Quaternion.AngleAxis(Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg, Vector3.forward);
        //c.transform.localRotation *= Quaternion.AngleAxis(Mathf.Sin(Joysticks.RStick.CappedInput.magnitude) * -40, Vector3.up);

        d.transform.localPosition = new Vector3(Joysticks.DPad.CappedInput.x, Joysticks.DPad.CappedInput.z) * 2f;
        d.transform.localEulerAngles = new Vector2(Joysticks.DPad.CappedInput.z, -Joysticks.DPad.CappedInput.x) * 20;

        float aFloat = 1 - Input.GetAxis("Jump") * 0.25f;
        a.color = new Color(aFloat, aFloat, aFloat);

        float bFloat = 1 - Input.GetAxis("Fire1") * 0.25f;
        b.color = new Color(bFloat, bFloat, bFloat);

        float xFloat = 1 - Input.GetAxis("Fire2") * 0.25f;
        x.color = new Color(xFloat, xFloat, xFloat);

        float yFloat = 1 - Input.GetAxis("Fire3") * 0.25f;
        y.color = new Color(yFloat, yFloat, yFloat);

        float startFloat = 1 - Input.GetAxis("Submit") * 0.25f;
        start.color = new Color(startFloat, startFloat, startFloat);

        //Bumpers/Triggers
        float lFloat = 1 - Input.GetAxis("L") * 0.25f;
        l.color = new Color(lFloat, lFloat, lFloat);

        float rFloat = 1 - Input.GetAxis("R") * 0.25f;
        r.color = new Color(rFloat, rFloat, rFloat);

        float zFloat = 1 - Input.GetAxis("Z") * 0.25f;
        z.color = new Color(zFloat, zFloat, zFloat);
    }
}
