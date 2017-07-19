using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class StatusEffect : MonoBehaviour
{
    StatusEffects effect; // identifier - matches enum
    StatusEffectType type; // Indicates if effect is a buff, a debuff, or neutral
    int level; // The strength of the effect; default is 0

}

public abstract class BattleStatusEffect : StatusEffect
{
    public abstract void TriggerEffect();
}

public abstract class WorldStatusEffect : StatusEffect
{
    public abstract void StartEffect();
    public abstract
}
