using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class UnicornHorns : Weapon
{
    bool exploding = false;

    protected override void Attack()
    {
        base.Attack();

        Vector3 mp = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        Vector3 dir = mp - transform.position;

        Vector3 lookDir = Input.mousePosition - Camera.main.WorldToScreenPoint(transform.position);
        
        DelayedSpawn(0, dir, lookDir);
        DelayedSpawn(300, dir, lookDir);
        DelayedSpawn(600, dir, lookDir);

    }

    async void DelayedSpawn(int delay, Vector3 mousePos, Vector3 lookDir)
    {
        await Task.Delay(delay);

        GameObject horn = Instantiate(WeaponPrefab, transform.position, WeaponPrefab.transform.rotation);
        horn.GetComponent<Rigidbody2D>().velocity = mousePos * 2;
        horn.GetComponent<HurtEnemyOnTrigger>().Damage = WeaponData.Damage + DamageIncrease + PermDamageIncrease;
        if (exploding) horn.AddComponent<ExplodeOnTrigger>().dmg = 75;

        var angle = Mathf.Atan2(lookDir.y, lookDir.x) * Mathf.Rad2Deg;
        horn.transform.rotation = Quaternion.AngleAxis(angle - 90, Vector3.forward);

        Destroy(horn, 5);
    }

    public override void Upgrade(int level)
    {
        base.Upgrade(level);

        DamageIncrease += 5;
        if (WeaponData.Cooldown - CooldownReduction > 1) CooldownReduction += 0.3f;

        if(level == 5)
        {
            exploding = true;
        }
    }

    public override void ApplyPermUpgrade(int level)
    {
        base.ApplyPermUpgrade(level);

        for (int i = 0; i < level; i++)
        {
            CooldownReduction += 0.15f;
        }
    }
}
