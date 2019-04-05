using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class BattleEntity
{

    public Transform transform;

    public int battleSlot;

    public int ID;
    public int currentHealth, maxhealth;
    public int baseAttack, currentAttack;
    public int baseDefence, currentDefence;
    public bool healthIsVisible;
    public bool isPlayer;

    public Dictionary<StatusEffects, StatusEffect> statusEffects = new Dictionary<StatusEffects, StatusEffect>();
    public Dictionary<StatusEffects, StatusEffect> permanentEffects = new Dictionary<StatusEffects, StatusEffect>();

    public HashSet<StatusEffects> permanentImmunities = new HashSet<StatusEffects>();
    public HashSet<StatusEffects> temporaryImmunities = new HashSet<StatusEffects>();
    public float jumpAttackOffset;
    public Animator animator;
    public Elements element;
    public GroundStates groundState;
    public List<Attack> attacks;
    public bool canAttack;
    public bool allowDeath;

    /*public bool IsGrounded()
    {
        return groundState == (GroundStates.Ground | GroundStates.Ceiling | GroundStates.Underground);
    }*/

        //gives an entity a set amount of HP
    public void GiveHealth(int amount)
    {
        animator.Play("PoweredUp");
        currentHealth = Mathf.Min(maxhealth + amount, maxhealth);
    }

    //if has effect (enum input)
    public bool HasStatusEffect(StatusEffects effect)
    {
        if (statusEffects.ContainsKey(effect))
            return true;
        if (permanentEffects.ContainsKey(effect))
            return true;
        return false;
    }

    //Attempt afflicting entity with the given status effect
    public void TryGiveStatusEffect(StatusEffect effect)
    {
        //so long as the entity is not immune to the effect
        if (!IsImmuneTo(effect.effect))
        {
            //if entity does not have the statuseffect, give it to it.
            if (!statusEffects.ContainsKey(effect.effect))
                statusEffects.Add(effect.effect, effect);
            //otherwise, check its reapply behaviour
            else
                switch (effect.reapplyBehaviour)
                {
                    case StatusEffectReapplyBehaviour.No_Effect:
                        //does literally nothing.
                        break;
                    case StatusEffectReapplyBehaviour.Stack:
                        statusEffects[effect.effect].level += effect.level;
                        break;
                    case StatusEffectReapplyBehaviour.Extend:
                        statusEffects[effect.effect].length += effect.length;
                        break;
                    case StatusEffectReapplyBehaviour.Burst:
                        ((BattleStatusEffect)statusEffects[effect.effect]).Burst();
                        break;
                    case StatusEffectReapplyBehaviour.Reset:
                        statusEffects[effect.effect].length = effect.length;
                        break;
                    case StatusEffectReapplyBehaviour.Remove:
                        statusEffects.Remove(effect.effect);
                        break;
                }
        }
    }
    public void TryGiveStatusEffects(StatusEffect[] effects)
    {
        foreach (BattleStatusEffect effect in effects)
            TryGiveStatusEffect(effect);
    }

    public void RemoveStatusEffects(StatusEffects[] effects)
    {
        foreach (StatusEffects effect in effects)
            statusEffects.Remove(effect);
    }
    public void RemoveStatusEffect(StatusEffects effect)
    {
        statusEffects.Remove(effect);
    }
    public bool IsImmuneTo(StatusEffects effect)
    {
        if (temporaryImmunities.Contains(effect) || permanentImmunities.Contains(effect))
            return true;
        return false;
    }

    bool IsWeakAgainst(Elements element)
    {
        return false;//replace with elemt damage calculation
    }
    bool IsStrongAgainst(Elements element)
    {
        return false;//replace with elemt damage calculation
    }
    
    void TryDamage(Attack attack, int basePower)
    {
        int totalDamage;

        //if is a nonpiercing attack
        if (!attack.isPiercing)
            totalDamage = Mathf.Min(basePower - currentDefence, 0);
        //if is a piercing attack
        else totalDamage = basePower;

        if (IsWeakTo(attack.element))
            totalDamage += 2;
        else if (IsStrongTo(attack.element))
            totalDamage -= 2;

        if (element == attack.element && attack.element != Elements.None)
            GiveHealth(totalDamage);

        if (totalDamage > 0)
        {
            currentHealth = Mathf.Max(currentHealth - totalDamage, 0);
            animator.Play("Damaged");
        }
        else
            //play 'no damage' particle effects
            animator.Play("Undamaged");
    }

    public void TryToDamage(BattleEntity target, Attack attack, int basePower)
    {
        foreach (StatusEffect eff in statusEffects.Values)
        {
            ((BattleStatusEffect)eff).Activate(EffectActivationTrigger.On_Attack);
        }
        foreach (StatusEffect eff in permanentEffects.Values)
        {
            ((BattleStatusEffect)eff).Activate(EffectActivationTrigger.On_Attack);
        }
        target.TryDamage(attack, basePower);
    }

    public void TryIfnflictStatus(StatusEffect effect)
    {
        bool hasEffect = HasStatusEffect(effect.effect);
        
    }

    void DoDamageAnimation()
    {

    }
    IEnumerator StartDamageAnimation(ActionAnimation a)
    {
        animator.Play("Damaged");//“Damaged”
        if (currentHealth != 0)
        {
            yield return new WaitForSeconds(2);
            animator.Play("Idle");
        }

        /*else while (currentHealth == 0)
        {
            if (allowDeathAnimation)
            {
                animator.Play("Death");
                break;
            }
                yield return new WaitForFixedUpdate();
        }*/
        yield return new WaitForSeconds(1);
        if (currentHealth > 0)
            animator.Play("Idle");
        //else yield return new WaitUntil(a.isDone);
        animator.Play("Death");
    }

}
