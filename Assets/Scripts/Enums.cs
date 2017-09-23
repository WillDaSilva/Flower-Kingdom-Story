
public enum ItemType
{
    Consumable,
    Badge,
    Important
}

public enum EffectActivationTrigger
{
    Turn_Start,
    Move_Start,
    On_Hit, // Entity gets hit by enemy
    On_Attack // Entity attacks enemy
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
    Asleep,     //Immoblile. Being hit has chance of waking affected up
    Drowsy,     //Will fall asleep in 1 turn
    Blind,      //Acton command prompts are harder to see
    Burned,     //Afflicted will take fire damage each turn
    DEF_Down,   //Decreases defence of the afflicted
    DEF_Up,     //Increases defence of the afflicted
    Dizzy,      //Afflicted will take random attacks
    Agile,      //Afflicted has a chance of dodging attacks
    Fast,       //Can do 2 actions in 1 turn
    Slow,       //Do 1 action every second turn
    Electrified,
    Frozen,     //Renders affliced immobile. Fire will cancel this status
    Large,      //+2 attack power
    Shrunk,     //-2 Attack power
    Immobilized,//Unable to do any actions
    Invisible,  //Intangible, can't be hit
    ATK_Down,   //Decreases attack
    ATK_Up,     //Increases attack
    Spiked,     //Can't be hit by physical attacks
    Charmed,    //
    Poisoned,   //Afflicted takes damage every turn
    Regen,      //Regenerates health
    No_Items,   //Can't use any items
    Danger,     //Low HP
    Angry       //Increased damage, decreased defense
}

public enum Elements
{
    None,
    Fire,
    Ice,
    Wind,
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
