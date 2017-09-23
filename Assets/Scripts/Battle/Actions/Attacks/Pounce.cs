using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bounce: AttackAnimation
{
    //Animator[] users[0].animator, target[0].animator;

    CameraFollower camfollower;
    protected int i = 0;
    float y;
    float gravity = -30;
    float distance;
    protected float percent;
    float hitTime = 0.065f;
    Vector3 startPosition, endPosition, offsetPosition;

    protected float walkSpeed = 5;

    protected float startTime, airTime;

    protected float jumpHitHeight;

    protected float[] maxHeights = new float[]{ 2+1, 2+1, 1.5f+1 };
    protected float time;


    bool canDo;

    public override void Start(BattleEntity[] user, BattleEntity[] target)
    {
        base.Start(user, target);
        camfollower = Camera.main.transform.GetComponent<CameraFollower>();
        i = 0;
        startTime = Time.fixedTime;
        startPosition = Managers.battleManager.startPositions[users[0].battleSlot];
        endPosition = Managers.battleManager.startPositions[targets[0].battleSlot];
        offsetPosition = endPosition - 2 * Vector3.right;
        distance = Vector3.Distance(startPosition, offsetPosition);
        jumpHitHeight = targets[0].transform.position.y + targets[0].jumpAttackOffset;
        
        users[0].animator.Play("Walk");
        i = 0;
    }
    public override void Update()
    {
        time = Time.fixedTime - startTime;

        switch (i) // action index
        {
            #region Succsseful
            case 0: //walk right
                y = 0;
                percent = Mathf.Clamp01(time / (distance / walkSpeed));
                users[0].transform.position = Vector3.Lerp(startPosition, offsetPosition, percent);

                if (percent >= 1)
                {
                    startTime = Time.fixedTime;
                    airTime = Parabola.CalculateHitTime(0, maxHeights[0] + jumpHitHeight, jumpHitHeight, gravity);
                    i = 1;

                    users[0].animator.Play("Jump");
                }
                break;

            case 1: //jump on enemy
                //if (time == 0)

                percent = Mathf.Clamp01(time / airTime);
                y = Parabola.Calculate(0, jumpHitHeight + maxHeights[0], gravity, time);
                if (y < jumpHitHeight && percent>0.9f)
                    y = jumpHitHeight;
                users[0].transform.position = Vector3.Lerp(offsetPosition, endPosition, percent) + y * Vector3.up;
                if (percent >= 1)
                {
                    startTime = Time.fixedTime;
                    i = 101;
                    users[0].animator.Play("JumpHit");
                }
                break;
                
            case 101: //first hit (Action command here)
                if (time >= hitTime)
                {
                    startTime = Time.fixedTime;
                    airTime = Parabola.CalculateHitTime(0, maxHeights[1], 0, gravity);
                    users[0].transform.position = endPosition + jumpHitHeight * Vector3.up;
                    i = 2;
                    users[0].animator.Play("Jump");
                }
                break;
            case 2: //bounce off enemy, back onto enemy
                y = Mathf.Max(Parabola.Calculate(0, maxHeights[1], gravity, time),0) + targets[0].jumpAttackOffset;
                users[0].transform.position = targets[0].transform.position + y * Vector3.up;

                //Vector3 rot = 360 * (1.5f*time / airTime) * Vector3.up;
                //users[0].transform.GetChild(0).transform.eulerAngles = rot;
                if (time >= airTime)
                {
                    startTime = Time.fixedTime;
                    offsetPosition -= Vector3.right;//targets[0].transform.position - 3 * Vector3.right;
                    airTime = Parabola.CalculateHitTime(jumpHitHeight, jumpHitHeight + maxHeights[2], 0, gravity);
                    i=102;
                    canDo = true;
                    users[0].animator.Play("JumpHit");
                }
                break;
            case 102://second hit (Action command here)
                if (time >= hitTime)
                {
                    startTime = Time.fixedTime;
                    i = 3;
                    canDo = true;
                    users[0].animator.Play("Jump");
                }
                break;
            case 3: //bounce off enemy on to ground
                percent = Mathf.Clamp01(time / airTime);
                y = Parabola.Calculate(targets[0].transform.position.y + targets[0].jumpAttackOffset, targets[0].transform.position.y + targets[0].jumpAttackOffset + maxHeights[2], gravity, time);
                y = Mathf.Max(y, 0);
                users[0].transform.position = Vector3.Lerp(endPosition, offsetPosition, percent) + Vector3.up * y;

                //rot = Vector3.zero;//(360 * (0.5f * time / airTime) + 180)* Vector3.up + 360 * (time / airTime) * Vector3.right;
                //users[0].transform.GetChild(0).transform.eulerAngles = rot;
                if (percent >= 1)
                {
                    users[0].transform.GetChild(0).transform.eulerAngles = Vector3.zero;
                    startTime = Time.fixedTime;
                    i=5;

                    users[0].animator.Play("Walk");
                }

                break;
            case 4:
                if (time >= 0.3 )
                {
                    startTime = Time.fixedTime;
                    i++;

                    users[0].animator.Play("Walk");
                }
                break;
            case 5://walk left back to start position

                percent = time / (distance / walkSpeed); //Mathf.Clamp01((walkSpeed * time) / distance);
                users[0].transform.position = Vector3.Lerp(offsetPosition, startPosition, percent);
                if (percent >= 1)
                {
                    users[0].animator.Play("Idle");
                    isDone = true;
                }
                break;
            #endregion
            case 21:

                break;
        }
        //time = Time.fixedTime - startTime;
    }
}
public class Pounce: Bounce
{
    public override void Start(BattleEntity[] user, BattleEntity[] target)
    {
        maxHeights = new float[] {3,3,2};
        base.Start(user, target);
    }
    public override void Update()
    {
        //Vector3 lastPosition = users[0].transform.position;
        base.Update();
        time = Time.fixedTime - startTime;
        //Vector3 normalizedDirection = (users[0].transform.position - lastPosition).normalized;
        switch (i)
        {
            case 1:
                float slope = Parabola.CalculateSlope(0, maxHeights[1] + jumpHitHeight, -40, time);
                users[0].transform.GetChild(0).localEulerAngles = Vector3.back * Vector3.Angle(Vector3.up, (new Vector3(time, slope) + users[0].transform.position).normalized);
                break;
            case 2:
                float angle = Mathf.Lerp(0, 180, time/(airTime/2)-0.5f);
                users[0].transform.GetChild(0).localEulerAngles = Vector3.back * angle;
                break;
            case 101:
            case 102:
                break;
            default:
                users[0].transform.GetChild(0).localEulerAngles = Vector3.zero;
                break;

        }
        //Debug.Log(normalizedDirection);
    }
}
