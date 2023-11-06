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

public class GiggleGunUpgrade : Upgrade
{
    private void Start()
    {
        upgradeName = "Giggle Gun";
        rarity = 100;
        baseDescription = "Shoots deadly laughing faces in random directions";
        equippedDescription = "Increase Damage and faces shot";
    }

    public override void Equip()
    {
        base.Equip();
        WeaponManager.Instance.gameObject.GetComponent<GiggleGun>().Activate();
    }

    public override void LevelUp()
    {
        base.LevelUp();
        WeaponManager.Instance.gameObject.GetComponent <GiggleGun>().Upgrade(level);
    }
}

public class MarshmellowMaceUpgrade : Upgrade
{
    private void Start()
    {
        upgradeName = "Marshmellow Mace";
        rarity = 100;
        baseDescription = "Constant swining mace around the player";
        equippedDescription = "Increase Damage";
    }

    public override void Equip()
    {
        base.Equip();
        WeaponManager.Instance.gameObject.GetComponent<MarshmellowMace>().Activate();
    }

    public override void LevelUp()
    {
        base.LevelUp();
        WeaponManager.Instance.gameObject.GetComponent<MarshmellowMace>().Upgrade(level);
    }
}

public class BouncyBallUpgrade : Upgrade
{
    private void Start()
    {
        upgradeName = "Bouncy Balls";
        rarity = 100;
        baseDescription = "Fire a bouncy ball in a random direction hitting off enemies";
        equippedDescription = "Increase Damage and balls fired";
    }

    public override void Equip()
    {
        base.Equip();
        WeaponManager.Instance.gameObject.GetComponent<BouncyBalls>().Activate();
    }

    public override void LevelUp()
    {
        base.LevelUp();
        WeaponManager.Instance.gameObject.GetComponent<BouncyBalls>().Upgrade(level);
    }
}

public class SockPuppetUpgrade : Upgrade
{
    private void Start()
    {
        upgradeName = "Sock Puppet";
        rarity = 100;
        baseDescription = "Sling sock puppets around the player";
        equippedDescription = "Increase damage and puppets slung";
    }

    public override void Equip()
    {
        base.Equip();
        WeaponManager.Instance.gameObject.GetComponent<SockPuppetSling>().Activate();
    }

    public override void LevelUp()
    {
        base.LevelUp();
        WeaponManager.Instance.gameObject.GetComponent<SockPuppetSling>().Upgrade(level);
    }
}

public class JigsawSlicerUpgrade : Upgrade
{
    private void Start()
    {
        upgradeName = "Jigsaw Slicer";
        rarity = 100;
        baseDescription = "Shoots puzzle pieces in all directions";
        equippedDescription = "Increase damage and decrease cooldown";
    }

    public override void Equip()
    {
        base.Equip();
        WeaponManager.Instance.gameObject.GetComponent<JigsawSlicer>().Activate();
    }

    public override void LevelUp()
    {
        base.LevelUp();
        WeaponManager.Instance.gameObject.GetComponent<JigsawSlicer>().Upgrade(level);
    }
}

public class UnicornHornUpgrade : Upgrade
{
    private void Start()
    {
        upgradeName = "Unicorn Horn";
        rarity = 100;
        baseDescription = "Fires a unicorns horn towards the mouse";
        equippedDescription = "Increase damage and reduce cooldown";
    }

    public override void Equip()
    {
        base.Equip();
        WeaponManager.Instance.gameObject.GetComponent<UnicornHorns>().Activate();
    }

    public override void LevelUp()
    {
        base.LevelUp();
        WeaponManager.Instance.gameObject.GetComponent<UnicornHorns>().Upgrade(level);
    }
}
