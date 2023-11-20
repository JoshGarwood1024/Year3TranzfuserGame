using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SockPuppetSling : Weapon
{
    int puppetCount = 1;

    protected override void Attack()
    {
        base.Attack();

        if(MaxLevel)
        {
            GameObject sockPuppet = Instantiate(WeaponPrefab, transform.position, transform.rotation);
            sockPuppet.GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle * 4;
            sockPuppet.AddComponent<SockPuppet>().attackDmg = 30 + PermDamageIncrease;
        } else
        {
            for (int i = 0; i < puppetCount; i++)
            {
                GameObject sockPuppet = Instantiate(WeaponPrefab, transform.position, transform.rotation);
                sockPuppet.GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle * 15;
                sockPuppet.AddComponent<HurtEnemyOnTrigger>().Damage = WeaponData.Damage + DamageIncrease + PermDamageIncrease;
                sockPuppet.AddComponent<DestroyOnImpactTrigger>();
            }
        }
    }

    protected override void Update()
    {
        base.Update();
    }

    public override void Upgrade(int level)
    {
        base.Upgrade(level);

        DamageIncrease += 5;
        puppetCount++;

        if (MaxLevel) CooldownReduction = -10;
    }

    public override void ApplyPermUpgrade(int level)
    {
        base.ApplyPermUpgrade(level);

        for(int i = 0; i < level; i++)
        {
            PermDamageIncrease += 20;
        }
    }
}

