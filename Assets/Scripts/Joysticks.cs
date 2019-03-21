using UnityEngine;
using System.Collections;

public class Joysticks : MonoBehaviour {
    
    public static bool Jump, JumpUp, JumpDown, JumpPress;

    public static Joystick LStick, RStick, DPad;
    void Start()
    {
        LStick = new Joystick();
        LStick.stepAmount = 3;
        RStick = new Joystick();
        RStick.stepAmount = 3;
        DPad = new Joystick();
        DPad.stepAmount = 1;
    }
	void Update () {
        LStick.UpdateAxes(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
        RStick.UpdateAxes(Input.GetAxis("Horizontal2"), Input.GetAxis("Vertical2"));
        DPad.UpdateAxes(Input.GetAxis("HorizontalD"), Input.GetAxis("VerticalD"));
        Jump = Input.GetButton("Jump");
        JumpDown = Input.GetButtonDown("Jump");
        JumpUp = Input.GetButtonUp("Jump");
        
        
    }
}
[System.Serializable]
public class Joystick
{
    public Vector3 NormalizedInput, CappedInput, StepInput;
    public float stepMagnitude;
    public float stepAmount;

    public void UpdateAxes(float h, float v)
    {
        NormalizedInput = new Vector3(h, 0, v).normalized;
        CappedInput = Vector3.ClampMagnitude(new Vector3(h, 0, v), 1);
        stepMagnitude = Mathf.Round(stepAmount * CappedInput.magnitude) / stepAmount;
        StepInput = NormalizedInput * stepMagnitude;
    }
}