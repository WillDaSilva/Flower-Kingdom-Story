using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    public float maxSpeed;
    Rigidbody rigidBody;
    public GroundCheck groundCheck;
    _4WaySpriteRotation spriteRotation;
    Billboarder billboarder;
    SpriteSwapper swapper;

    Animator animator;
    public float baseJumpStrength, midJumpStrength;
    Transform rotationT;

    void Awake()
    {
        rigidBody = GetComponent<Rigidbody>();
        groundCheck = GetComponent<GroundCheck>();
        spriteRotation = GetComponentInChildren<_4WaySpriteRotation>();
        animator = GetComponentInChildren<Animator>();
        billboarder = GetComponentInChildren<Billboarder>();
        rotationT = transform.GetChild(0);
        swapper = GetComponentInChildren<SpriteSwapper>();
    }
    void Start()
    {

    }

    void Update()
    {
        if (Input.GetButtonDown("Jump"))
        {
            if (groundCheck.grounded)
                rigidBody.velocity = Vector3.up * baseJumpStrength;
        }
    }

    void FixedUpdate()
    {
        float r = spriteRotation.currentAngle;// * 2;


        if (Input.GetButton("Jump") && !groundCheck.grounded && rigidBody.velocity.y > 0)
            rigidBody.AddForce(midJumpStrength * Vector3.up, ForceMode.Acceleration);
        if (groundCheck.grounded)
            #region rotation check/set
            if (Input.GetAxis("Vertical") > 0)
            {
                if (Input.GetAxis("Horizontal") < 0)
                {
                    spriteRotation.targetAngle = 180;
                }
                else if (Input.GetAxis("Horizontal") > 0)
                {
                    spriteRotation.targetAngle = 270;
                }

                if (spriteRotation.targetAngle == 90)
                {
                    spriteRotation.targetAngle = 180;
                }
                else if (spriteRotation.targetAngle == 0)
                {
                    spriteRotation.targetAngle = 270;
                }
            }
            else if (Input.GetAxis("Horizontal") != 0)
            {
                if (Input.GetAxis("Horizontal") < 0)
                {
                    spriteRotation.targetAngle = 90;
                }
                else if (Input.GetAxis("Horizontal") > 0)
                {
                    spriteRotation.targetAngle = 0;
                }
                /*if (spriteRotation.targetAngle == 180)
                {
                    spriteRotation.targetAngle = 90;
                }
                else if (spriteRotation.targetAngle == 270)
                {
                    spriteRotation.targetAngle = 0;
                }*/
            }
            else if (Input.GetAxis("Vertical") < 0)
            {
                if (spriteRotation.targetAngle == 180)
                {
                    spriteRotation.targetAngle = 90;
                }
                else if (spriteRotation.targetAngle == 270)
                {
                    spriteRotation.targetAngle = 0;
                }
            }
        #endregion
        float totaZScale = billboarder.zScale;// * billboarder.camSide;
        if (r > 0 && r < 90)        //backright to backleft
        {
            rotationT.localScale = new Vector3(billboarder.camSide, 1, totaZScale);
            swapper.LoadSprites(null);
        }
        else if (r > 90 && r < 180) //backleft to topleft
        {
            rotationT.localScale = new Vector3(-totaZScale, 1, totaZScale);
            if (totaZScale == 1)
                swapper.LoadSprites("back");
            else if (totaZScale == -1)
                swapper.LoadSprites(null);
        }
        else if (r > 180 && r < 270)//topleft to topright
        {
            rotationT.localScale = new Vector3(-billboarder.camSide, 1, totaZScale);
            swapper.LoadSprites("back");
        }
        else if (r > 270 && r < 720)//topright to backright
        {
            rotationT.localScale = new Vector3(totaZScale, 1, totaZScale);
            if (totaZScale == 1)
                swapper.LoadSprites(null);
            else if (totaZScale == -1)
                swapper.LoadSprites("back");
        }
        //print("r: " + r + "camSide: " + billboarder.camSide + " zScale: " + billboarder.zScale + " ");
        //print(r)
        //print(rigidBody.velocity.y);
        //if()
        //Vector3[] casts = new Vector3 { }
        if (groundCheck.grounded)
        {
            rigidBody.velocity = Joysticks.LStick.StepInput * maxSpeed + Vector3.up * rigidBody.velocity.y;
            if (Joysticks.LStick.StepInput.magnitude != 0)
                //if (rigidBody.velocity.magnitude > 0.1)
                animator.Play("Walk");
            else animator.Play("Idle");
        }
        else
        {
            rigidBody.AddForce(Joysticks.LStick.StepInput * maxSpeed);
            animator.Play("Jump");
        }
        groundCheck.jumping = Mathf.Abs(rigidBody.velocity.y) > 1f;


    }
}
