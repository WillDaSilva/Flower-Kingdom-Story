using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Obsolete("This is an obsolete class")]
public abstract class AttackAnimation {

    public BattleEntity[] users, targets;
    public Vector3[] userStartPositions, enemyStartPositions;
    //public bool isOffset; //attack starting position is offset from target (true) rather than absolute (false);
    public bool isDone = true;
    public virtual void Start(BattleEntity[] user, BattleEntity[] target, Attack attack)
    {
        users = user;
        targets = target;
        isDone = false;
    }
    //Consuming Items
    public virtual void Start(BattleEntity[] user, HealthItem item) { isDone = false; }
    //Attacking Items
    //public virtual void Start(BattleEntity[] user, BattleEntity[] target, AttackItem item) { Start(user, target); }
    //public void Start() { isDone = false; }

    public virtual void Update()
    {
        /*foreach (BattleEntity user in users)
        {

        }*/
        //isDone = true;
    } //BattleEntity[] users, BattleEntity[] targets);
    public ActionCommandType actionCommand;

}
