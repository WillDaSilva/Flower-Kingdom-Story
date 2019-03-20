
public enum ItemType
{
    Consumable,
    Badge,
    Important
}
public enum HealthItemType
{
    Food,
    Drink,
    Other
}

public enum EffectActivationTrigger
{
    /// <summary>
    /// Before any entities have gone. Technically also counts as after all entities have gotten a turn.
    /// </summary>
    Turn_Start,
    /// <summary>
    /// When entity begins its own turn
    /// </summary>
    Move_Start,
    /// <summary>
    /// When entity gets attacked by enemy
    /// </summary>
    On_Hit,
    /// <summary>
    /// When entity attacks enemy
    /// </summary>
    On_Attack
}

public enum StatusEffectType
{
    Positive, // Buff
    Neutral,
    Negative // Debuff
}

public enum StatusEffectReapplyBehaviour
{
    /// <summary>
    /// Effect cannot be applied when already afflicted
    /// </summary>
    No_Effect,
    /// <summary>
    /// Stacks the effects of it (Ex: can be burned multiple times)
    /// </summary>
    Stack,
    /// <summary>
    /// The duration of the effect is increased
    /// </summary>
    Extend,
    /// <summary>
    /// Does an instantaneous effect
    /// </summary>
    Burst,
    /// <summary>
    /// Resets the timer until it is removed
    /// </summary>
    Reset,
    /// <summary>
    /// Removes the effect
    /// </summary>
    Remove
}

public enum StatusEffects
{
    Blind,      //Acton command prompts are harder to see

    Burned,     //Afflicted will take fire damage each turn. Either water or ice will put it out.
    Poisoned,   //Afflicted takes damage every turn; +1 per level.

    ATK_Down,   //Decreases attack of the afflicted by -1 per level
    ATK_Up,     //Increases attack of the afflicted by +1 per level
    DEF_Down,   //Decreases defence of the afflicted by -1 per level
    DEF_Up,     //Increases defence of the afflicted by +1 per level

    Dizzy,      //Afflicted will take random attacks
    Agile,      //Afflicted has a chance of dodging attacks
    Fast,       //Can do 2 actions in 1 turn
    Slow,       //Do 1 action every second turn

    Drowsy,     //Will fall asleep in 1 turn.
    Asleep,     //Immoblile. Either being hit or a full round ending has chance of waking affected up. Level determines the chance of being woken up (chance = 1 / 2^level) At most, 4 turns may pass.
    Immobilized,//Unable to do any actions
    Frozen,     //Renders affliced immobile. Fire attacks will cancel this status
    Petrified,  //Renders affliced immobile, but defence is increased by 1 point per status level

    Trapped,    //Makes it so the afflicted can't run away

    Grown,      //+1 attack power per status effect level
    Shrunk,     //-1 Attack power per status effect level

    Invisible,  //entity can't be seen, can still be attacked if timed correctly
    Intangible, //Can't be hit

    Spiked,     //Can't be hit by physical attacks and does normal damage on the attacker
    Electrifying,//Can't be hit by physical attacks and inflicts electrical damage on the attacker.

    Charmed,    //Affected will normally refuse to attack the caster, but if still manages to attack, reduces the affected's attack.

    Regen,      //Regenerates health; +1 per level per turn
    No_Items,   //Can't use any items
    Danger,     //Low HP
    Angry       //Increased damage(+1/lev), decreased defense (-1/lev), more difficult to hit button prompts
}

public enum Elements
{
    None,
    Fire,
    Ice,
    Wind,
    Electricity,
    Explosion
}
public enum ActionCommandType
{
    Success,
    Defense = Success,
    Counter = Success,
    Fancy
}

public enum GroundStates
{
    Ground,
    Underground,
    Floating,
    Flying,
    Ceiling
}

public enum AttackablePositions
{
    Front,
    //Back,
    Any = Front//|Back
}

public enum BattleStates //From really early on. Not even sure if we'll need these anymore.
{
    Idle,
    Player,
    Enemy,
    Dialogue
}
