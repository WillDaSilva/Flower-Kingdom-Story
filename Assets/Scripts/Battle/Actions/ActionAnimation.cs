using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActionAnimation
{
    public ActionAnimation()
    {
        isDone = true;
    }
    protected float startTime, time;
    public string name { get; protected set; }
    public bool isDone { get; protected set; }
    protected virtual void OnStart() //Something
    {
        startTime = Time.fixedTime;
    }
    protected virtual void OnUpdate()
    {
        time = Time.fixedTime - startTime;
        if (isDone)
            OnAnimationComplete();
    }
    public void OnUpdatePublic()
    {
        OnUpdate();
    }
    public virtual void OnAnimationComplete()
    {
        Managers.battleManager.currentAction = null;
        isDone = true;
    }
    protected IEnumerator StartAnimation() //BattleEntity[] users, BattleEntity[] targets, Attack attack
    {
        yield return new WaitForFixedUpdate();
        OnStart();
        while (!isDone)
        {
            OnUpdate();
            yield return new WaitForFixedUpdate();
        }
    }
    /*public void Start(BattleEntity[] users, BattleEntity[] targets)
    {
        if(isDone)
        {

        }
    }*/

    /*protected virtual void OnStart(BattleEntity[] users, BattleEntity[] targets, Attack attack) //For Attack Animations
    {
        OnStart();
    }
    protected virtual void OnStart(BattleEntity[] users, HealthItem item)//For Healing Animations
    {
        OnStart();
    }
    protected virtual void OnStart(BattleEntity[] users, BattleEntity[] targets, Item item) //For Attack Animations
    {
        OnStart();
    }
    protected virtual void OnStart(BattleEntity[] targets, PropAction propAction) //For Attack Animations
    {
        OnStart();
    }*/
    /*public void Start()
    {
        Managers.battleManager.StartCoroutine(StartAnimation());
    }


    protected IEnumerator StartAnimation()
    {
        if (isDone)
        {
            OnStart();
            yield return new WaitForFixedUpdate();
            while (!isDone)
            {
                OnUpdate();
                yield return new WaitForFixedUpdate();
            }
        }
    }*/
}
/*
public class TempAttackAnimation : ActionAnimation
{
    public BattleEntity[] users, targets;
    public Attack attack;

    public void Start(BattleEntity[] users, BattleEntity[] targets, Attack attack)
    {
        Managers.battleManager.StartCoroutine(StartAnimation(users, targets, attack));
    }


    IEnumerator StartAnimation(BattleEntity[] users, BattleEntity[] targets, Attack attack)
    {
        if (isDone)
        {
            OnStart(users, targets, attack);
            yield return new WaitForFixedUpdate();
            while (!isDone)
            {
                OnUpdate();
                yield return new WaitForFixedUpdate();
            }
        }
    }

    protected override void OnStart(BattleEntity[] users, BattleEntity[] targets, Attack attack)
    {
        base.OnStart(users, targets, attack);
        this.users = users;
        this.targets = targets;
        this.attack = attack;

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
    }

    protected override void OnUpdate()
    {

    }

}
public class ItemUseAnimation : ActionAnimation
{
    public BattleEntity[] users, targets;
    public Item item;
    protected override void OnStart(BattleEntity[] users, BattleEntity[] targets, Attack attack)
    {
        throw new NotImplementedException();
    }
    protected override void OnStart(BattleEntity[] users, HealthItem item)//For Health Item Animations
    {
        this.users = users;
        this.item = item;
    }
    protected sealed override void OnStart(BattleEntity[] users, BattleEntity[] targets, Item item) //For Any Item Animations
    {
        this.users = users;
        this.targets = targets;
        this.item = item;

        base.OnStart(users, targets, item);
    }
    protected sealed override void OnStart(BattleEntity[] targets, PropAction propAction) //For prop Animations
    {
        throw new NotImplementedException();
    }

    protected override void OnUpdate()
    {

    }

}*/
