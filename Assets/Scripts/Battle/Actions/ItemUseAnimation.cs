using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemUseAnimation : ActionAnimation
{
    public BattleEntity[] users, targets;
    public Item item;
    protected void OnStart(BattleEntity[] users, HealthItem item)//For Health Item Animations
    {
        this.users = users;
        this.item = item;
    }
    protected void OnStart(BattleEntity[] users, BattleEntity[] targets, Item item) //For Any Item Animations
    {
        this.users = users;
        this.targets = targets;
        this.item = item;

        //base.OnStart(users, targets, item);
    }
    void Start(BattleEntity[] users, HealthItem item)
    {
        this.users = users;
        this.item = item;
    }
    void Start(BattleEntity[] users, BattleEntity[] targets, Item item)
    {
        this.users = users;
        this.targets = targets;
        this.item = item;
    }
    protected override void OnUpdate()
    {

    }

}