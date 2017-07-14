using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class Partner {
	public Partner()
    {

	}
	public string name;
	public int currentHealth;
	public int maxHealth;
	public int baseHealth;
	public int level;
	public int baseDefence, currentDefence;
	public int baseAttack, currentAttack;

	public Sprite sprite;

	public List<Attack> attacks;

	public bool found;
    public bool available;

    //public Behaviour ability;
}
//[System.Serializable]
//public class Partner : BasePartner{
	//int dispLevel = level + 1;
	//int attack = baseAttack + level;
	//int maxHP = baseHP + (level * 5);
//}