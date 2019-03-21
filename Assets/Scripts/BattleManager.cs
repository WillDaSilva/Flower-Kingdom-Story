using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using TMPro;
using System;

public class BattleManager : MonoBehaviour
{
    public BattleEntity[] battleEntities = new BattleEntity[8];
    [SerializeField]
    int maxPlayerEntities;//Max amount of partners that can be in battle (not including player)
    [SerializeField]
    int maxEnemyEntities; //Max amount of enemies that can be in battle
    //[SerializeField]
    public int turn;// { get; private set; } // turn number - ranges between 0 and (maxPartners+maxEnemies)(Ex)
    [SerializeField]
    bool trigger, trigger2; //temporary, for calling NextTurn() in editor
    public bool playerTurn { get; private set; }//is true when turn < maxPartners
    [SerializeField]
    int timesAround; //times every entity has gotten a turn and turn has overflowed back to 0
    public BattleStates battleState;
    public Action currentAction;


    public List<Vector3> startPositions;
    public List<Transform> startPositionTransforms;


    public Transform currentEntity_Arrow;

    void OnValidate()
    {
        int i = 0;
        foreach (Vector3 v3 in startPositions)
        {
            startPositions[i] = startPositionTransforms[i].position;
            i++;
        }
    }
    void Awake()
    {
        int i = 0;
        foreach(BattleEntity e in battleEntities)
        {
            e.battleSlot = i;
            i++;
        }
    }
    void Start()
    {
        playerTurn = true;
        UpdateEntityIndexes();
        foreach (BattleEntity e in battleEntities)
        {
            e.animator = e.transform.GetComponentInChildren<Animator>();
        }

        Attack pounce = new Attack("Pounce", true, Elements.None, AttackablePositions.Any, new GroundStates[] { GroundStates.Ground, GroundStates.Floating, GroundStates.Flying }, new Pounce());
        battleEntities[1].attacks.Add(pounce);
        battleEntities[0].currentHealth = Managers.Stats.currentHealth;
        if (maxPlayerEntities > 0)
            for (int i = 1; i > maxPlayerEntities; i++)
            {
                battleEntities[i].currentHealth = Managers.Stats.Partners[Managers.Stats.ActivePartners[i - 1]].currentHealth;

            }
        Managers.uiManager.UpdateHP();
    }
    void UpdateEntityIndexes()
    {
        int i = 0;
        foreach (BattleEntity be in battleEntities)
        {
            be.battleSlot = i;
            i++;
        }
    }
    void Update()
    {
        if (trigger)
        {
            trigger = false;
            NextTurn();
        }
        if (currentAction == null && !playerTurn)
        {
            NextTurn();
        }
        if (Input.GetButtonDown("Jump"))
        {
            battleEntities[1].attacks[0].Start(new BattleEntity[] { battleEntities[1] }, new BattleEntity[] { battleEntities[3] });
            
        }
        currentEntity_Arrow.position = Camera.main.WorldToScreenPoint(battleEntities[turn].transform.position + ((battleEntities[turn].jumpAttackOffset / 2) * Vector3.up));
        
    }
    void FixedUpdate()
    {
        if (currentAction != null && currentAction.animation != null)// && true == false)
        {
            currentAction.animation.OnUpdatePublic();
            if (currentAction.animation.isDone)
            {
                currentAction.animation.OnAnimationComplete();
                currentAction = null;
            }
        }
    }
    public void SwitchEntities(int i1, int i2)
    {
        BattleEntity temp = battleEntities[i1];
        battleEntities[i2] = battleEntities[i1];
        battleEntities[i1] = temp;
        UpdateEntityIndexes();
    }
    public void NextTurn()
    {
        if (!battleEntities[turn].HasStatusEffect(StatusEffects.Fast))
        {
            turn = Maths.Wrap(turn + 1, 0, 7);
            OnAllTurnsComplete();
            int i = 0;
            //keep skipping an entity's turn if it is unable to make a move
            while (!battleEntities[turn].canAttack) 
            {
                i++;
                NextTurn();
                OnAllTurnsComplete();
                //failsafe to prevent a crash for if nobody can make a move.
                if (i > 100)
                {
                    Debug.Log("BattleEntity at index " + i + " was unable to make a decision on what move to make.");
                    break;
                }
            }
            if (turn < maxPlayerEntities)
                playerTurn = true;
            else playerTurn = false;
        }
    }

    //an attack that does not use up a turn and is only obtainable through attacking an enemy in the overworld
    void FirstStrike(Attack strikeAttack)
    {

        /*switch (strikeType)
        {
            case "Yoyo":
                battleEntities[0].attacks[1].Start(new[] { battleEntities[0] }, new[] { battleEntities[maxPartners] });
                break;
            case "Punch":
                battleEntities[0].attacks[0].Start(new[] { battleEntities[0] }, new[] { battleEntities[maxPartners] });
                break;
            case "Jump":
                battleEntities[1].attacks[1].Start(new[] { battleEntities[0] }, new[] { battleEntities[maxPartners] });
                break;
            case "SpaceJump":
                battleEntities[1].attacks[2].Start(new[] { battleEntities[0] }, new[] { battleEntities[maxPartners] });
                break;
            case "MallowToss":
                break;
            case "Ice":
                break;
        }*/
    }
    //checks if turn has returned to 0, is not checked if entering into battle
    void OnAllTurnsComplete() 
    {
        if (turn == 0)
            timesAround++;
        {
            foreach (BattleEntity battleEntity in battleEntities)
            {
                foreach (StatusEffect statusEffect in battleEntity.statusEffects.Values)
                    ((BattleStatusEffect)statusEffect).Burst();
                //battleEntity.statusEffects.
            }
        }
    }
    public void LoadBattle()
    {

    }
    //the attack that you are struck by by an enemy in the overworld
    void Struck(Attack struckAttack)
    {

    }
    public void AddNewEntity()
    {

    }
}
