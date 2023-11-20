using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiggleGun : Weapon
{
    float faces = 1;

    protected override void Attack()
    {
        base.Attack();

        for (int i = 0; i < faces; i++)
        {
            GameObject laughingFace = Instantiate(WeaponPrefab, transform.position, Quaternion.identity);
            Vector3 playerDir = GetComponentInParent<SpriteRenderer>().flipX ? Vector3.left : Vector3.right;
            Vector3 randDir = Quaternion.Euler(0, 0, Random.Range(-30f, 30f)) * playerDir.normalized;
            laughingFace.GetComponent<Rigidbody2D>().velocity = randDir * 15;
            laughingFace.GetComponent<LaughingFace>().Dmg = WeaponData.Damage + DamageIncrease + PermDamageIncrease;
            if (MaxLevel) laughingFace.GetComponent<LaughingFace>().Active = true;
        }
    }

    public override void Upgrade(int level)
    {
        base.Upgrade(level);

        DamageIncrease += 10;
        faces++;
    }

    public override void ApplyPermUpgrade(int level)
    {
        base.ApplyPermUpgrade(level);

        for (int i = 0; i < level; i++)
        {
            CooldownReduction += 0.1f;
            PermDamageIncrease += 10;
        }
    }
}
