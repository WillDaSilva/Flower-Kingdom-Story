using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class AttackAnimation {

    public BattleEntity[] users, targets;
    public Vector3[] userStartPositions, enemyStartPositions;
    //public bool isOffset; //attack starting position is offset from target (true) rather than absolute (false);
    public bool isDone = true;
    public virtual void Start(BattleEntity[] user, BattleEntity[] target)
    {
        users = user;
        targets = target;
        isDone = false;
    }
    public virtual void Update()
    {
        /*foreach (BattleEntity user in users)
        {

        }*/
        isDone = true;
    } //BattleEntity[] users, BattleEntity[] targets);
    public ActionCommandType actionCommand;

}
