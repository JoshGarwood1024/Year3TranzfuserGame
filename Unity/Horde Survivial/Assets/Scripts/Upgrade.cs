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
        level = 1;
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
    }

    public override void Equip()
    {
        base.Equip();
        GameObject.Find("Player").GetComponent<PlayerHealth>().startMHealth += 5;
    }

    public override void LevelUp()
    {
        base.LevelUp();
        GameObject.Find("Player").GetComponent<PlayerHealth>().startMHealth += 5;
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
    }

    public override void Equip()
    {
        base.Equip();
        PlayerData.Instance.DamageBuff += 2;
    }

    public override void LevelUp()
    {
        base.LevelUp();
        PlayerData.Instance.DamageBuff += 2;
    }
}
//---------STARTING CLASSES--------

public class BreathingUpgrade : Upgrade
{
    private void Start()
    {
        upgradeName = "Breathing";
        rarity = 100;
        baseDescription = "START CLASS";
        equippedDescription = "Increase radius";
    }

    public override void Equip()
    {
        base.Equip();
        WeaponManager.Instance.gameObject.GetComponent<Breathing>().Activate();
    }

    public override void LevelUp()
    {
        base.LevelUp();
        WeaponManager.Instance.gameObject.GetComponent<Breathing>().Upgrade(level);
    }
}
//----------WEAPON UPGRADES------------
public class BalloonBombUpgrade : Upgrade
{
    private void Start()
    {
        upgradeName = "Balloon Bomb";
        rarity = 100;
        baseDescription = "Send an explosive balloon to the nearest enemy";
        equippedDescription = "Increase damage and balloons sent";
    }

    public override void Equip()
    {
        base.Equip();
        WeaponManager.Instance.gameObject.GetComponent<BalloonBombs>().Activate();
    }

    public override void LevelUp()
    {
        base.LevelUp();
        WeaponManager.Instance.gameObject.GetComponent<BalloonBombs>().Upgrade(level);
    }
}

public class PillowBatUpgrade : Upgrade
{
    private void Start()
    {
        upgradeName = "Pillow Bat";
        rarity = 100;
        baseDescription = "Sends a spiralling bat around the player";
        equippedDescription = "Increase Damage";
    }

    public override void Equip()
    {
        base.Equip();
        WeaponManager.Instance.gameObject.GetComponent<PillowBat>().Activate();
    }

    public override void LevelUp()
    {
        base.LevelUp();
        WeaponManager.Instance.gameObject.GetComponent<PillowBat>().Upgrade(level);
    }
}

public class BubbleGumBazookaUpgrade : Upgrade
{
    private void Start()
    {
        upgradeName = "BubbleGum Bazooka";
        rarity = 100;
        baseDescription = "Blast a piece of bubblegum in all directions!";
        equippedDescription = "Increase Damage and reduce cast time";
    }

    public override void Equip()
    {
        base.Equip();
        WeaponManager.Instance.gameObject.GetComponent<BubblegumBazooka>().Activate();
    }

    public override void LevelUp()
    {
        base.LevelUp();
        WeaponManager.Instance.gameObject.GetComponent <BubblegumBazooka>().Upgrade(level);
    }
}

public class FairyDustBlowerUpgrade : Upgrade
{
    private void Start()
    {
        upgradeName = "Fairy Dust Blower";
        rarity = 100;
        baseDescription = "Blow dust in the face of the enemies";
        equippedDescription = "Increase Damage and reduce cast time";
    }

    public override void Equip()
    {
        base.Equip();
        WeaponManager.Instance.gameObject.GetComponent<FairyDustBlower>().Activate();
    }

    public override void LevelUp()
    {
        base.LevelUp();
        WeaponManager.Instance.gameObject.GetComponent<FairyDustBlower>().Upgrade(level);
    }
}


