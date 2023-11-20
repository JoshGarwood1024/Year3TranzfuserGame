using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathing : Weapon
{
    public float Radius;
    public ParticleSystem ParticleEffect;

    protected override void Attack()
    {
        var sh = ParticleEffect.shape;
        sh.radius = Radius;
        ParticleEffect.Play();
        ParticleEffect.gameObject.GetComponent<FairyDust>().dmg = WeaponData.Damage + DamageIncrease + PermDamageIncrease;

        base.Attack();
    }

    protected override void Update()
    {
        base.Update();
    }
    public override void Upgrade(int level)
    {
        base.Upgrade(level);

        if (level <= 5)
        {
            Radius += 0.25f;
        }
    }

    public override void ApplyPermUpgrade(int level)
    {
        base.ApplyPermUpgrade(level);

        for(int i = 0; i < level; i++)
        {
            CooldownReduction = 0.1f;
            PermDamageIncrease += 20;
        }

    }
}
