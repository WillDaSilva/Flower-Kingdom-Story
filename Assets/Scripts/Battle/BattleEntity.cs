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

    public void GiveHealth(int amount)
    {
        currentHealth = Mathf.Min(maxhealth + amount, maxhealth);
    }
    public bool HasStatusEffect(StatusEffects effect)
    {
        if (statusEffects.ContainsKey(effect))
            return true;
        if (permanentEffects.ContainsKey(effect))
            return true;
        return false;
    }
    public bool HasStatusEffect(StatusEffect effect)
    {
        return HasStatusEffect(effect.effect);
    }

    public void GiveStatusEffect(StatusEffect effect)
    {
        if (HasStatusEffect(effect))
            statusEffects.Add(effect.effect, effect);
        else
            statusEffects[effect.effect] = effect;
    }
    public void GiveStatusEffects(StatusEffect[] effects)
    {
        foreach (StatusEffect eff in effects)
            GiveStatusEffect(eff);
    }

    public void RemoveStatusEffect(StatusEffects effect)
    {
        statusEffects.Remove(effect);
    }

    public void RemoveStatusEffects(StatusEffects[] effects)
    {
        foreach (StatusEffects effect in effects)
            RemoveStatusEffect(effect);
    }
    public bool IsImmuneTo(StatusEffects effect)
    {
        if (temporaryImmunities.Contains(effect) || permanentImmunities.Contains(effect))
            return true;
        return false;
    }
    public bool IsImmuneTo(StatusEffect effect)
    {
        return IsImmuneTo(effect.effect);
    }
    bool IsWeakTo(Elements element)
    {
        return false;//replace with elemt damage calculation
    }
    public void TryDamage(BattleEntity target, Attack attack, int basePower)
    {
        int totalDamage = basePower;
        //if (IsWeakTo(attack.element))
        //baseDamage += 2;

        if (!attack.piercing && basePower > currentDefence)
            totalDamage = Mathf.Max(basePower - currentDefence, 0);
        else if (basePower <= currentDefence)
            totalDamage = 0;
        else totalDamage = basePower;

        /*if (target.element == attack.element && attack.element != Elements.None)
        {
            target.GiveHealth(totalDamage);
            target.animator.Play("PoweredUp");
        }*/
        if (totalDamage != 0)
        {
            currentHealth = Mathf.Max(currentHealth - totalDamage, 0);
            target.animator.Play("Damaged");
        }
        else 
        {
            //play 'no damage' particle effects
            target.animator.Play("Undamaged");
        }

    }
    public void TryIfnflictStatus(StatusEffect effect)
    {
        bool hasEffect = HasStatusEffect(effect);
        if (!hasEffect && !IsImmuneTo(effect))
            statusEffects.Add(effect.effect, effect);
        else if (hasEffect)
            statusEffects[effect.effect] = effect;
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
