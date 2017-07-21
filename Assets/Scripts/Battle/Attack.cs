using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[System.Serializable]
public class Attack
{
    public List<GroundStates> attackableHeights;
    public AttackablePos attackablePositions;
    public Elements element;
    public bool physical;
    public bool piercing;
}
