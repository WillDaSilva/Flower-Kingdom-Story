using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BattleEntity
{
    public int ID;
    public int currentHealth, maxhealth;
    public int baseAttack, currentAttack;
    public int[] defense;
    public bool healthIsVisible;

    public Dictionary<BattleEnums.StatusEffects, StatusEffect> statusEffects;
    public Dictionary<BattleEnums.StatusEffects, StatusEffect> permanentEffects;

    public List<BattleEnums.StatusEffects> permanentImmunities;
    public List<BattleEnums.StatusEffects> temporaryImmunities;

    public BattleEnums.Elements element;
    public BattleEnums.GroundStates groundState;
    public List<Attack> attacks;
    public bool canAttack;

    public bool Grounded()
    {
        return groundState == (BattleEnums.GroundStates.ground | BattleEnums.GroundStates.ceiling);
    }
}
