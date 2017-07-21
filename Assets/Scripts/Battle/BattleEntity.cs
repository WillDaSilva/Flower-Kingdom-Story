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

    public List<StatusEffects> statusEffects;

    public List<StatusEffects> permanentImmunities;
    public List<StatusEffects> temporaryImmunities;

    public Elements element;
    public GroundStates groundState;
    public List<Attack> attacks;
    public bool canAttack;

    public bool Grounded()
    {
        return groundState == (GroundStates.Ground | GroundStates.Ceiling | GroundStates.Underground);
    }
}
