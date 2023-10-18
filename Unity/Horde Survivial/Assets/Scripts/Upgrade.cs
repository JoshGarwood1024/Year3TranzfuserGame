using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{

    public string upgradeName { get; set; }
    public float rarity { get; set; }
    public string description { get; set; }
    public int level { get; set; }

    public virtual void Equip() { }
    public virtual void Use() { }

    public virtual void GetLevelUpgrade() { }
    public virtual void LevelUp() { }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class HealthUpgrade : Upgrade
{
    private void Start()
    {
        upgradeName = "Health Upgrade";
        rarity = 100;
        description = "Increase health by 10";
        level = 1;
    }

    public override void Equip()
    {
        GameObject.Find("Player").GetComponent<PlayerHealth>().startMHealth += 10;
        PlayerHealth.PHealth = GameObject.Find("Player").GetComponent<PlayerHealth>().startMHealth;
    }

    public override void LevelUp()
    {
        GameObject.Find("Player").GetComponent<PlayerHealth>().startMHealth += 10;
        level++;
    }
}

public class SlashAttack : Upgrade
{
    private void Start()
    {
        upgradeName = "Slash Attack";
        rarity = 100;
        description = "Send a 360 slash around the player hurting nearby enemies";
        level = 1;
    }

    public override void LevelUp()
    {
        GetComponent<CircleCollider2D>().radius += 1;
    }
}

public class Upgrade2 : Upgrade
{
    private void Start()
    {
        upgradeName = "test2";
        rarity = 100;
        description = "test2";
        level = 1;
    }
}