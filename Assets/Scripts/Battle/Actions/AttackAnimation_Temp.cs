using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempAttackAnimation : ActionAnimation
{
    protected BattleEntity[] users, targets;
    protected Attack attack;

    public void Start(BattleEntity[] users, BattleEntity[] targets, Attack attack)
    {
        if (isDone)
        {
            isDone = false;
            this.users = users;
            this.targets = targets;
            this.attack = attack;
            //Managers.battleManager.StartCoroutine(StartAnimation());//users, targets, attack
            OnStart();
        }
    }
    protected override void OnStart()
    {
        base.OnStart();
    }
    protected override void OnUpdate()
    {
        base.OnUpdate();
    }

    /*protected void OnStart(BattleEntity[] users, BattleEntity[] targets, Attack attack)
    {
        //base.OnStart(users, targets, attack);

    }
    protected sealed override void OnStart(BattleEntity[] users, HealthItem item)//For Health Item Animations
    {
        throw new NotImplementedException();
    }
    protected sealed override void OnStart(BattleEntity[] users, BattleEntity[] targets, Item item) //For Any Item Animations
    {
        throw new NotImplementedException();
    }
    protected sealed override void OnStart(BattleEntity[] targets, PropAction propAction) //For prop Animations
    {
        throw new NotImplementedException();
    }*/

}

