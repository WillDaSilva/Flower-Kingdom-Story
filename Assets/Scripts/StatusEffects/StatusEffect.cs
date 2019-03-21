using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect
{
    public StatusEffects effect; // identifier - matches enum
    public StatusEffectType type; // Indicates if effect is a buff, a debuff, or neutral
    public StatusEffectReapplyBehaviour reapplyBehaviour;
    public int level; // The strength of the effect; default is 0
    public int length; // The length of the effect; default is 1. if WorldStatusEffect, length is number of ticks. -1 means infinite.
}

public abstract class BattleStatusEffect : StatusEffect
{
    public abstract void Activate(EffectActivationTrigger effectActivationTrigger);
    public virtual void Burst()
    {

    }
}
public class Burn: BattleStatusEffect
{
    public override void Activate(EffectActivationTrigger effectActivationTrigger)
    {
        
    }
}
public abstract class WorldStatusEffect : StatusEffect
{
    public abstract void StartEffect();
}