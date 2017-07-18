using UnityEngine;
using System.Collections;
using System.Collections.Generic;
//using TMPro;
using System;

public class BattleManager : MonoBehaviour {
    public BattleEntity[] battleEntities = new BattleEntity[8];
    [SerializeField]
    int maxPartners;//Max amount of partners that can be in battle (not including player)
    [SerializeField]
    int maxEnemies; //Max amount of enemies that can be in battle
    public int turn { get; private set; } // turn number - ranges between 0 and (maxPartners+maxEnemies)(Ex)
    [SerializeField]
    bool trigger, trigger2; //temporary, for calling NextTurn() in editor
    public bool playerTurn { get; private set; }//is true when turn < maxPartners
    [SerializeField]
    int timesAround; //times every entity has gotten a turn and turn has overflowed back to 0
    public BattleStates battleState;

    void Start()
    {
        battleEntities[0].currentHealth = Managers.Stats.currentHealth;
        if (maxPartners > 0)
            for (int i = 1; i > maxPartners; i++)
            {
                battleEntities[i].currentHealth = Managers.Stats.Partners[Managers.Stats.ActivePartners[i - 1]].currentHealth;

            }
        Managers.uiManager.UpdateHP();
    }

    void Update()
    {
        if (trigger)
        {
            trigger = false;
            NextTurn();
            
        }
    }

    void NextTurn()
    {
        turn = Math.Wrap(turn + 1, 0, 7);
        OnAllComplete();
            int i = 0;
            while (!battleEntities[turn].canAttack) //keep skipping an entity's turn if it is unable to make a move
            {
                i++;
                NextTurn();
                OnAllComplete();
                if (i > 100) //failsafe to prevent a crash.
                    break;
            }
            if (turn < maxPartners)
                playerTurn = true;
            else playerTurn = false;
    }

    void FirstStrike()
    {

    }

    void OnAllComplete() //checks if turn has returned to 0, is not checked if entering into battle
    {

        if (turn == 0)
            timesAround++;
        {
            foreach (BattleEntity battleEntity in battleEntities)
            {
                //battleEntity.RunStatusEffects();
            }
        }
    }

    void Struck()
    {

    }
}
