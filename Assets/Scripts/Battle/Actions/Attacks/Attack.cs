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
        piercing = isPiercing;
        this.element = element;
        attackablePositions = pos;
        foreach (GroundStates groundState in gs)
            attackableHeights.Add(groundState);
    }
    public Attack(string attackName) // To be used for creating new instances of an existing attack instance with only a name
    {
        name = attackName;


    }
    /*Attack(BattleEntity[] user, BattleEntity[] target)
    {
        users = targets;
    }*/
    public virtual int CalculateAttackPower()
    {
        return 0;
    }
    //public int attackPower;
    public HashSet<GroundStates> attackableHeights = new HashSet<GroundStates>();
    public AttackablePositions attackablePositions { get; private set; }
    public Elements element { get; private set; }
    public bool physical { get; private set; }
    public bool piercing { get; private set; }
    [System.Obsolete("Can be identified with a 'physicaal' boolean instead")]public bool counterCancelsAttack { get; private set; }
    //new public TempAttackAnimation animation { get; private set; }
    public void Start(BattleEntity[] users, BattleEntity[] targets)
    {
        if (Managers.battleManager.currentAction == null || Managers.battleManager.currentAction.animation.isDone) //Managers.battleManager.currentAction == null
        {
            //if (animation.isDone)
            Managers.battleManager.currentAction = this;
            ((TempAttackAnimation)animation).Start(users, targets, this);
        }
        else
            Debug.LogError("You can't start an attack if it's already started!");
        
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
