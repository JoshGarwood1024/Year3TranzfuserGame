using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Upgrade : MonoBehaviour
{

    public string upgradeName { get; set; }
    public float rarity { get; set; }
    public string baseDescription { get; set; }
    public string equippedDescription { get; set; }
    public int level { get; set; }

    public virtual void Equip() {
        level++;
    }
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
        Debug.Log(upgradeName + ": " + level);
    }
}
//-----------UPGRADES-------------
public class HealthUpgrade : Upgrade
{
    private void Start()
    {
        upgradeName = "Health Upgrade";
        rarity = 100;
        baseDescription = "Increase health by 5";
        equippedDescription = "Increase health by 5";
        level = 0;
    }

    public override void Equip()
    {
        base.Equip();
        GameObject.Find("Player").GetComponent<PlayerHealth>().startMHealth += 10;
        PlayerHealth.PHealth = GameObject.Find("Player").GetComponent<PlayerHealth>().startMHealth;
    }

    public override void LevelUp()
    {
        GameObject.Find("Player").GetComponent<PlayerHealth>().startMHealth += 5;
        level++;
    }
}
public class DamageUpgrade : Upgrade
{
    private void Start()
    {
        upgradeName = "Damage Buff";
        rarity = 100;
        baseDescription = "Increase your damage by 2";
        equippedDescription = "Increase your damage by 2";
        level = 0;
    }

    public override void Equip()
    {
        base.Equip();
    }

    public override void LevelUp()
    {
        level++;
    }
}
