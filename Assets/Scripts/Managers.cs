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

        battleManager = GameObject.Find("BattleManager").GetComponent<BattleManager>();
        
        uiManager = GetComponentInChildren<UIManager>();
        Stats = transform.FindChild("SharedStats").GetComponent<SharedStats>();//GetComponentInChildren<SharedStats>();
        
            Transform t = GameObject.FindWithTag("Player").transform;
        
    }
    void Start()
    {
        GameObject[] allObjects = FindObjectsOfType<GameObject>();
        foreach (GameObject obj in allObjects)
        {
            Renderer spriteRenderer = obj.GetComponent<SpriteRenderer>();
            if (spriteRenderer != null)
            {
                spriteRenderer.shadowCastingMode = UnityEngine.Rendering.ShadowCastingMode.On;
                spriteRenderer.receiveShadows = true;
            }
        }
    }
}
