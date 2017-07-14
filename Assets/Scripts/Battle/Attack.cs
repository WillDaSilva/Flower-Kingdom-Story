using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public class Attack
{
    List<BattleEnums.GroundStates> attackableHeights;
    BattleEnums.AttackablePos attackablePositions;
    bool physical;
    BattleEnums.Elements element;
    int baseStrength;
}
