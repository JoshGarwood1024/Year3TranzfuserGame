using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu]
public class LootTables : ScriptableObject
{
    public Sprite lootSprite;
    public string LootName;
    public int dropChance;


    public LootTables(string lootName, int dropChance)
    {
        this.LootName = lootName;
        this.dropChance = dropChance;
    }

}
