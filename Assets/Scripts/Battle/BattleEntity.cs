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
    public int defence;
    public bool healthIsVisible;

    public Dictionary<StatusEffects, StatusEffect> statusEffects = new Dictionary<StatusEffects, StatusEffect>();
    public Dictionary<StatusEffects, StatusEffect> permanentEffects = new Dictionary<StatusEffects, StatusEffect>();

    public LinkedHashSet<StatusEffects> permanentImmunities = new LinkedHashSet<StatusEffects>();
    public LinkedHashSet<StatusEffects> temporaryImmunities = new LinkedHashSet<StatusEffects>();
    public float jumpAttackOffset;
    public Animator animator;
    public Elements element;
    public GroundStates groundState;
    public List<Attack> attacks;
    public bool canAttack;


    /*public bool IsGrounded()
    {
        return groundState == (GroundStates.Ground | GroundStates.Ceiling | GroundStates.Underground);
    }*/

    public void GiveHealth(int amount)
    {

    }
    public bool HasStatusEffect(StatusEffects effect)
    {
        if (statusEffects.ContainsKey(effect))
            return true;
        if (permanentEffects.ContainsKey(effect))
            return true;
        return false;
    }

    public static void TryDamage(BattleEntity user, BattleEntity target, Attack attack, int power)
    {
        int userDamage = user.currentAttack + power;
        int totalDamage = Mathf.Max(userDamage-target.defence, 0);
        if (target.element == attack.element)
            target.GiveHealth(totalDamage);
        else target.currentHealth = Mathf.Max(target.currentHealth - totalDamage, 0);

    }
    public static void TryIfnflictStatus()
    {

    }
}
