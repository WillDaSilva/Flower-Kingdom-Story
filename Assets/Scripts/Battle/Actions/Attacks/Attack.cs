using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]

public class Attack: Action
{
    public string name;
    public Attack(string attackName, bool isPiercing, Elements element, AttackablePositions pos, GroundStates[] gs, TempAttackAnimation atkAnimation)
    {
        name = attackName;
        animation = atkAnimation;
        this.isPiercing = isPiercing;
        this.element = element;
        attackablePositions = pos;
        foreach (GroundStates groundState in gs)
            attackableHeights.Add(groundState);
    }
    // To be used for creating new instances of an existing attack instance with only a name
    public Attack(string attackName) 
    {
        name = attackName;
        
    }
    /*Attack(BattleEntity[] user, BattleEntity[] target)
    {
        users = targets;
    }*/
    //Default method of calcuating the amount of attack power that will be inflicted. May be overridden.
    public virtual int CalculateAttackPower()
    {
        int totalDamage = 0;

        return totalDamage;
    }
    //The height values the attack may be targeted towards;
    public HashSet<GroundStates> attackableHeights = new HashSet<GroundStates>();
    //whether the attack can be directed towards either the frontmost, or any target. I should probably just replace it with a bool.
    public AttackablePositions attackablePositions;
    //the element modifier of the attack
    public Elements element { get; private set; }
    //whether body-to-body contact is made with the target
    public bool isPhysical { get; private set; }
    //whether the attack value bypasses the defence value of the target.
    public bool isPiercing { get; private set; }
    public bool reboundableProjectile { get; private set; }
    [System.Obsolete("Should be identified with the 'isPhysical' boolean instead")]
    public bool counterCancelsAttack { get; private set; }
    //new public TempAttackAnimation animation { get; private set; }
    public void Start(BattleEntity[] users, BattleEntity[] targets)
    {
        if (Managers.battleManager.currentAction == null || Managers.battleManager.currentAction.animation.isDone) //Managers.battleManager.currentAction == null
        {
            Managers.battleManager.currentAction = this;
            ((TempAttackAnimation)animation).Start(users, targets, this);
        }
        else
            Debug.LogError("You can't start an attack if one has already started!");
        
    }
    /*
    IEnumerator StartAttack(BattleEntity[] users, BattleEntity[] targets)
    {
        yield return new WaitForFixedUpdate();
        if (animation.isDone)
        {
            //if (string.IsNullOrEmpty(name))
                //name = GetType().ToString();

            Debug.Log("Started '" + name + "' Attack");
            animation.Start(users, targets, this);
            while (!animation.isDone) //called as if in update, but without the functions requiring to be called continuously
            {
                yield return new WaitForFixedUpdate();
                animation.Update();
            }
            Managers.battleManager.NextTurn();
            Debug.Log("Ended attack");

            animation.isDone = true;
        }
    }*/
}
