using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.Events;

public class UIManager : MonoBehaviour {
    public List<HPPair> HPText;
    [Space(10)]
    public Text CurrentAbilityPointsText;
    public Text MaxAbilityPointsText;
    public Text CoinsText;
    public Text EXPText;
    public Text ShardPowerText;
    [Space(10)]
    public GameObject dialogueUI;
    //public UIWriter UIW;
    //public VIDE_Data dialogue;
    public BattleManager battleManager;
    public List<UnityEvent> events;

    void Awake()
    {
        //battleManager = GetComponent<BattleManager>();
    }
    void Start()
    {
        /*int i = 0;
        foreach (HPPair hpp in HPText) {
            HPText[i].HPText.text = Managers.battleManager.battleEntities[i].HP.ToString();
            HPText[i].maxHPText.text = Managers.battleManager.battleEntities[i].MaxHP.ToString();
            i++;
        }*/
    }
    /*void UpdateHPTexts()
    {
        HPText[0].HPText.text = SuperManager.Stats.HP.ToString();
        HPText[0].maxHPText.text = SuperManager.Stats.maxHP.ToString();

        HPText[1].HPText.text = SuperManager.Stats.Partners[SuperManager.Stats.ActivePartners[0]].HP.ToString();
        HPText[1].maxHPText.text = SuperManager.Stats.Partners[SuperManager.Stats.ActivePartners[0]].maxHP.ToString();
        HPText[2].HPText.text = SuperManager.Stats.Partners[SuperManager.Stats.ActivePartners[1]].HP.ToString();
        HPText[2].maxHPText.text = SuperManager.Stats.Partners[SuperManager.Stats.ActivePartners[1]].maxHP.ToString();
    }*/
    void UpdateCurrentHP()
    {

    }
    public void UpdateHP()
    {
        //HPText[0].text = SuperManager.Stats.HP.ToString();
        int i = 0;
        foreach (HPPair HPT in HPText)
        {
            //HPT.text = SuperManager.Stats.Partners[SuperManager.Stats.ActivePartners[i]].HP.ToString();
            HPT.HPText.text = battleManager.battleEntities[i].currentHealth.ToString();
            i++;
        }
    }
    public void UpdateCoins()
    {
        CoinsText.text = Managers.Stats.coins.ToString();
    }

    /*public void UpdateHP()
    {
        //SuperManager.UIM.up
        HPText[0].HPText.text = stats.HP.ToString();
        HPText[1].HPText.text = SuperManager.DisplayStats.Partners[stats.ActivePartners[0]].HP.ToString();
        HPText[2].HPText.text = stats.Partners[stats.ActivePartners[1]].HP.ToString();
    }
    public void UpdateMaxHP()
    {
        HPText[0].MaxHPText.text = stats.maxHP.ToString();
        HPText[1].MaxHPText.text = stats.Partners[stats.ActivePartners[0]].maxHP.ToString();
        HPText[2].MaxHPText.text = stats.Partners[stats.ActivePartners[1]].maxHP.ToString();
    }
    public void UpdateFP()
    {
        FPText.text = stats.FP.ToString();
    }
    public void UpdateCoins()
    {
        CoinsText.text = stats.coins.ToString();
    }
    public void UpdateStarPow()
    {

    }*/
}
[System.Serializable]public class HPPair
{
    public Text HPText, maxHPText;
}
