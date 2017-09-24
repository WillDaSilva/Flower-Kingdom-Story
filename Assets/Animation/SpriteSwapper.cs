using System;
using System.Collections.Generic;
using UnityEngine;

public class SpriteSwapper : MonoBehaviour {

    public List<string> names;
    public List<SpriteListWrapper> altSpriteSheetList = new List<SpriteListWrapper>();

    List<Sprite> currentSprites = new List<Sprite>();
    Dictionary<string, List<Sprite>> spriteDict = new Dictionary<string, List<Sprite>>();
    
    SpriteRenderer[] renderers;
    void Start()
    {
        LoadRenderers();
        int i = 0;
        foreach (SpriteListWrapper assl in altSpriteSheetList)
        {
            spriteDict.Add(names[i], altSpriteSheetList[i].list);
            i++;
        }
    }

    void LoadRenderers()
    {
        renderers = GetComponentsInChildren<SpriteRenderer>();
    }

    public void LoadSprites(string sheetName)
    {
        if (string.IsNullOrEmpty(sheetName))
            currentSprites = null;
        else
            currentSprites = spriteDict[sheetName];
    }

    void LateUpdate()
    {
        if (spriteDict.Keys.Count != 0 && currentSprites != null)
            foreach (SpriteRenderer renderer in renderers)
            {
                string spriteName = renderer.sprite.name;
                Sprite newSprite = Array.Find(currentSprites.ToArray(), item => item.name == spriteName);

                if (newSprite)
                    renderer.sprite = newSprite;
            }
    }
}
/*
public class AltSpriteSwapper : MonoBehaviour
{

    public List<Sprite> altSpriteSheetList = new List<Sprite>();
    public Dictionary<string, Sprite> altSprites = new Dictionary<string, Sprite>();
    public List<string> spriteSheetNames;
    SpriteRenderer[] renderers;
    void LoadSprites()
    {
        altSprites.Clear();
        foreach (Sprite s in altSpriteSheetList)
        {
            altSprites.Add(s.name, s);
        }
        renderers = GetComponentsInChildren<SpriteRenderer>();
    }

    void FixedUpdate()
    {
        foreach (SpriteRenderer renderer in renderers)
        {
            string spriteName = renderer.sprite.name;
            Sprite newSprite = altSprites[spriteName];

            if (newSprite)
                renderer.sprite = newSprite;
        }
    }
}
*/
