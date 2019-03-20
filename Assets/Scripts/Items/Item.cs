using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Item
{
    public Item(int ID, string itemName, Sprite itemSprite, List<string> itemFlavourText)
    {
        name = itemName;
        ID = id;
        flavourText = itemFlavourText;
        sprite = itemSprite;
    }
    public int id { get; private set; }
    public string name { get; private set; }
    public Sprite sprite { get; private set; }
    public List<string> flavourText { get; private set; }
    public StatusEffects[] healsEffects { get; private set; }
    public StatusEffect[] givesEffects;
}
public abstract class ConsumableItem: Item
{
    public ConsumableItem(int ID, string itemName, Sprite itemSprite, List<string> itemFlavourText) : base(ID, itemName, itemSprite, itemFlavourText)
    {

    }

    public abstract void Use(BattleEntity[] users, BattleEntity[] targets);
}
public class HealthItem : ConsumableItem
{
    public EatAnimation animation;
    public int healthAmount { get; private set; }
    public int apAmount { get; private set; }

    public HealthItemType foodType { get; private set; }
    public HealthItem(int ID, string itemName, Sprite itemSprite, List<string> itemFlavourText, int health, int ap, HealthItemType foodType) : base(ID, itemName, itemSprite, itemFlavourText)
    {
        this.foodType = foodType; 
        animation = new EatAnimation();
    }

    public override void Use(BattleEntity[] users, BattleEntity[] targets)
    {
        animation.Start(users, this);
    }
    public virtual void TryConsume(BattleEntity user)
    {
        user.GiveHealth(healthAmount);
        if (user.isPlayer)
            Managers.Stats.GiveAP(apAmount);
        foreach (StatusEffects eff in healsEffects)
            if (user.HasStatusEffect(eff))
                user.statusEffects.Remove(eff);
        user.TryGiveStatusEffects(givesEffects);
    }
    public virtual void TryConsume(BattleEntity[] users)
    {
        foreach (BattleEntity entity in users)
            TryConsume(entity);
    }
}
public class AttackItem : ConsumableItem
{
    public ItemUseAnimation attackAnimation { get; private set; }
    public AttackItem(int ID, string itemName, Sprite itemSprite, List<string> itemFlavourText, ItemUseAnimation attackAnimation) : base(ID, itemName, itemSprite, itemFlavourText)
    {
        this.attackAnimation = attackAnimation;
    }

    public override void Use(BattleEntity[] users, BattleEntity[] targets)
    {
        throw new NotImplementedException();
    }
}
/*public class KeyItem: Item
{
    public KeyItem(int ID, string itemName, Sprite itemSprite, List<string> itemFlavourText)
    {
        name = itemName;
        id = ID;
        flavourText = itemFlavourText;
        sprite = itemSprite;
    }
}*/
