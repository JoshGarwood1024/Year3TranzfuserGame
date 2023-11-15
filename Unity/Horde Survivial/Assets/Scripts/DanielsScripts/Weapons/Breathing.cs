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
        ParticleEffect.gameObject.GetComponent<FairyDust>().dmg = WeaponData.Damage + DamageIncrease;

        base.Attack();
    }

    protected override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.N))
        {
            Upgrade(currentLevel);
        }
    }
    public override void Upgrade(int level)
    {
        base.Upgrade(level);

        if (level <= 5)
        {
            Radius += 0.25f;
        }
    }
}
