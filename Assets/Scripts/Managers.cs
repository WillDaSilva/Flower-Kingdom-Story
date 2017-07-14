using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Managers: MonoBehaviour {
    public static BattleManager battleManager;
    public static UIManager uiManager;
    public static SharedStats Stats;
    void Awake()
    {
        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        uiManager = GetComponentInChildren<UIManager>();
        Stats = transform.FindChild("SharedStats").GetComponent<SharedStats>();//GetComponentInChildren<SharedStats>();
    }
}
