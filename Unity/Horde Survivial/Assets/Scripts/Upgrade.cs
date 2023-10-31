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
    public virtual void LevelUp() {
        level++;
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
        equippedDescription = baseDescription;
        level = 0;
    }

    public override void Equip()
    {
        base.Equip();
        GameObject.Find("Player").GetComponent<PlayerHealth>().startMHealth += 5;
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
        PlayerData.Instance.DamageBuff += 2;
    }

    public override void LevelUp()
    {
        PlayerData.Instance.DamageBuff += 2;
    }
}

//----------WEAPON UPGRADES------------
public class BalloonBombUpgrade : Upgrade
{
    private void Start()
    {
        upgradeName = "BalloonBombUpgrade";
        rarity = 100;
        baseDescription = "Send an explosive balloon to the nearest enemy";
        equippedDescription = "Increase damage and balloons sent";
        level = 0;
    }

    public override void Equip()
    {
        base.Equip();
        WeaponManager.Instance.gameObject.GetComponent<BalloonBombs>().active = true;
    }

    public override void LevelUp()
    {
        WeaponManager.Instance.gameObject.GetComponent<BalloonBombs>().Upgrade();
    }
}

