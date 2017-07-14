using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect
{
    BattleEnums.StatusEffects effect; //This is here as an identifier - it's a type or ID in a sense.
    int level; //The strength of the statuseffect, can be used if relevent;
    bool isBuff; //A tag to show if if the status effect gives positive or nagative effects. Doesn't actually do anything.
}

public abstract class BattleStatusEffect : StatusEffect
{
    public abstract void TriggerEffect();
}

public abstract class WorldStatusEffect : StatusEffect
{
    public abstract void StartEffect();
}