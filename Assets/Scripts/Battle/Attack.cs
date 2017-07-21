using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Attack
{
    public List<BattleEnums.GroundStates> attackableHeights;
    public BattleEnums.AttackablePos attackablePositions;
    public BattleEnums.Elements element;
    public bool physical;
    public bool piercing;
}
