using UnityEngine;
using System.Collections;


public enum ItemTypes { Consumable, Badge, Important }

//Status effects are not an enum

public enum StatusEffects
{
    Asleep, Drowsy, Blind, Burned,
    DEF_Down, DEF_Up, Dizzy, Agile, Electrified,
    Frozen, Large, Immobilized, Invisible,
    ATK_Down, ATK_Up, Spiked, Charmed,
    Poisoned, Regen, Shrunk, NoItems,
    //Permanent Status Effects

    //Health Effects
    Danger, Angry
}

/*
Alternate StatusEffects enum setup

public enum AltStatusEffects
{
    SLP, BLD, BRN,
    DEF_Down, DEF_Up, DZY, AGL, ELC,
    Fast, FRZ, Big, IMM, INV,
    ATK_Down, ATK_Up, Spiked,
    PSN, Regen, Shrunk, Slow, Tiny,
    //Permanent Status Effects
    Spiky,
    //Health Effects
    Danger, Angry
}
*/
public enum Elements
{
    None, Fire, Ice, Wind, Explosion
}

public enum GroundStates { ground, underground, floating, flying, ceiling }

public enum AttackablePos { front, any }

public enum BattleStates { idle, player, enemy, dialogue } //From really early on. Not even sure if we'll need these anymore.

