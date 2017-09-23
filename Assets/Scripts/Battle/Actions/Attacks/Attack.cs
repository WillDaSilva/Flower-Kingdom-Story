using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Attack: Action
{
    public Attack(string attackName,AttackablePositions pos, GroundStates[] gs, AttackAnimation atkAnimation)
    {
        name = attackName;
        animation = atkAnimation;
        attackablePositions = pos;
        foreach (GroundStates groundState in gs)
            attackableHeights.Add(groundState);

    }
    /*Attack(BattleEntity[] user, BattleEntity[] target)
    {
        users = targets;
    }*/
    public int CalculateAttackPower()
    {

        return 1;
    }
    //public int attackPower;
    public HashSet<GroundStates>attackableHeights= new HashSet<GroundStates>();
    public AttackablePositions attackablePositions;
    public Elements element;
    public bool physical;
    public bool piercing;
    public AttackAnimation animation { get; private set; }
    public void Start(BattleEntity[] users, BattleEntity[] targets)
    {
        if (animation.isDone)
            Managers.battleManager.StartCoroutine(StartAttack(users, targets));
        else
            Debug.LogError("You can start an attack if it's already started!");
    }
    IEnumerator StartAttack(BattleEntity[] users, BattleEntity[] targets)
    {
        yield return new WaitForFixedUpdate();
        if (animation.isDone)
        {
            if (string.IsNullOrEmpty(name))
                name = GetType().ToString();

            Debug.Log("Started '" + name + "' Attack");
            animation.Start(users, targets);
            while (!animation.isDone) //called as if in update, but without the functions requiring to be called continuously
            {
                yield return new WaitForFixedUpdate();
                animation.Update();
            }
            Managers.battleManager.NextTurn();
            Debug.Log("Ended attack");

            animation.isDone = true;
        }
    }
}
