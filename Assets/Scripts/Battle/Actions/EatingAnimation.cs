using System.Collections;
using System.Collections.Generic;
using UnityEngine;
/*
public class EatingAnimation: ItemUseAnimation
{
    float startTime;
    int i;
    BattleEntity[] users;
    HealthItem item;
    public void Start(BattleEntity[] users, HealthItem item)
    {
        this.users = users;
        this.item = item;
    }
    protected override void OnStart()
    {
        base.OnStart(users, item);
        this.item = item;
        users[0].animator.Play("UseItem");
        i = 0;
        startTime = Time.time;
    }
    protected override void OnUpdate()
    {
        float time = Time.fixedTime - startTime;
        if (i == 0 && time >= 1)
        {
            startTime = Time.time;
            switch (((HealthItem)item).foodType)
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
            item.TryConsume(users);
            //users[0].GiveHealth(item.apAmount);
            i++;
        }
        else if (i == 1 && time > 2)
        {
            isDone = true;
            users[0].animator.Play("Idle");
        }
        base.OnUpdate();
    }

}
*/