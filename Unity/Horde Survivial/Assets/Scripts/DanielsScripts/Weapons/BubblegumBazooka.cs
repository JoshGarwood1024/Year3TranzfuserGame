using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BubblegumBazooka : Weapon
{
    protected override void Attack()
    {
        base.Attack();

        for(int i = 0; i < 4; i++)
        {
            GameObject bubblegum = Instantiate(WeaponPrefab, transform.position, Quaternion.identity);
            if (MaxLevel) bubblegum.transform.localScale *= 1.5f;
            bubblegum.transform.Rotate(new Vector3(0, 0, i * 90));
            bubblegum.GetComponent<Rigidbody2D>().AddForce(bubblegum.transform.up * 20, ForceMode2D.Impulse);
            bubblegum.GetComponent<HurtEnemyOnTrigger>().Damage = WeaponData.Damage + DamageIncrease + PermDamageIncrease;
        }
    }

    public override void Upgrade(int level)
    {
        base.Upgrade(level);

        DamageIncrease += 5;
        CooldownReduction += 0.25f;
    }

    public override void ApplyPermUpgrade(int level)
    {
        base.ApplyPermUpgrade(level);

        for (int i = 0; i < level; i++)
        {
            CooldownReduction += 0.2f;
            PermDamageIncrease += 10;
        }
    }
}
