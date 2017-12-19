using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EatAnimation : ActionAnimation //Actually Action Animation
{
    HealthItem item;
    BattleEntity[] users, targets;
    int i;

    public void Start(BattleEntity[] users, HealthItem item)
    {
        this.users = users;
        this.item = item;
    }
    protected override void OnStart()
    {
        base.OnStart();
        //this.item = item;
        users[0].animator.Play("UseItem");
        i = 0;
        startTime = Time.time;
    }
    protected override void OnUpdate()
    {
        base.OnUpdate();
        if (i == 0 && time >= 1)
        {
            startTime = Time.time;

            foreach (BattleEntity user in users)
            {
                switch (item.foodType)
                {
                    case HealthItemType.Food:
                        users[0].animator.Play("Eat");
                        break;
                    case HealthItemType.Drink:
                        users[0].animator.Play("Drink");
                        break;
                    case HealthItemType.Other:
                        users[0].animator.Play("UseItem");
                        break;
                }
            }
            //users[0].GiveHealth(item.apAmount);
            i++;
        }
        else if (i == 1 && time >= 2)
        {
            foreach (BattleEntity user in users)
                item.TryConsume(users);
            i++;
        }
        else if (i == 2 && time >= 3)
        {
            isDone = true;
            users[0].animator.Play("Idle");
        }
    }
}
