using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[SerializeField]
public class Attack
{
    List<GroundStates> attackableHeights;
    AttackablePos attackablePositions;
    bool physical;
    Elements element;
    int baseStrength;
}
