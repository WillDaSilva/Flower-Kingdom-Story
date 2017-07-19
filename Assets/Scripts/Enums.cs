using UnityEngine;
using System.Collections;

public enum StatusEffects
{
    Consumable,
    Badge,
    Important
}

public enum StatusEffectType
{
    Positive, // Buff
    Neutral,
    Negative // Debuff
}

public enum StatusEffectReapplyBehaviour
{
    No_Effect, // Effect cannot be applied when already afflicted,
    Stack, // Stacks the effects of it (Ex: can be burned multiple times)
    Extend, // The duration of the effect is increased
    Burst, // Does an instantaneous effect
    Reset, // Resets the timer until it is removed
    Remove // Removes the effect
}

public enum StatusEffects
{
    Asleep,
    Drowsy,
    Blind,
    Burned,
    DEF_Down,
    DEF_Up,
    Dizzy,
    Agile,
    Electrified,
    Frozen,
    Large,
    Immobilized,
    Invisible,
    ATK_Down,
    ATK_Up,
    Spiked,
    Charmed,
    Poisoned,
    Regen,
    Shrunk,
    No_Items,
    Danger,
    Angry
}

public enum Elements
{
    None,
    Fire,
    Ice,
    Wind,
    Explosion
}

public enum GroundStates
{
    Ground,
    Underground,
    Floating,
    Flying,
    Ceiling
}

public enum AttackablePos
{
    Front,
    Back,
    Any
}

public enum BattleStates //From really early on. Not even sure if we'll need these anymore.
{
    Idle,
    Player,
    Enemy,
    Dialogue
}
>>>>>>> Stashed changes
