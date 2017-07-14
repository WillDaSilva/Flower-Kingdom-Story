using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SharedStats : MonoBehaviour {
    public enum StatType {HP,AP,Coins,SP };
	public int currentHealth; //Yes, I know I could just use commas, but this just looks better
	public int maxHealth;
	public int baseHealth;
	public int healthLevel;

	public int abilityPoints;
	public int maxAbilityPoints;
	public int baseAbilityPoints;
	public int abilityPointsLevel;

	public int emblemPoints;
	public int maxEmblemPoints;
	public int emblemPointsLevel;

	//public List<Badges> allBadges = new List<Badges>;

	public int EXP;
	public int level;

	public float shardPower;
	public float maxShardPower;
	public int coins;
    public int maxCoins;

    public List<Partner> Partners;
    public List<int> ActivePartners; //It's a List<int> so we can reference the partner through Partners[ActivePartners[i]]

    public Inventory inventory;//

    /*public void ChangeStats(StatType sT, int value)
    {
        switch (sT)
        {
            case StatType.Coins:
                coins = Mathf.Clamp(coins + value, 0, maxCoins);
                UIToggle.TriggerUI();
                break;
            case StatType.HP:
                HP += value;
                break;
            case StatType.FP:
                FP += value;
                break;
            case StatType.StarPow:
                starPower += value;
                break;
        }
    }*/
}
[System.Serializable]
public class Inventory
{
    public int maxSize;
    public List<int> normalItems;
    

    public List<int> specialItems;//<id>
}
