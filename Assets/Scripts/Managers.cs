using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
public class Managers: MonoBehaviour {
    public static BattleManager battleManager;
    public static UIManager uiManager;
    public static SharedStats Stats;
    public static PlayerController controller;
    void Awake()
    {

        battleManager = FindObjectOfType<BattleManager>();
        
        uiManager = GetComponentInChildren<UIManager>();
        Stats = transform.FindChild("SharedStats").GetComponent<SharedStats>();//GetComponentInChildren<SharedStats>();
        
            Transform t = GameObject.FindWithTag("Player").transform;
        
    }
    void Start()
    {
        SpriteRenderer[] allObjects = FindObjectsOfType<SpriteRenderer>();
        foreach (SpriteRenderer spriteRenderer in allObjects)
        {
                spriteRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                spriteRenderer.receiveShadows = true;
        }
    }
}
