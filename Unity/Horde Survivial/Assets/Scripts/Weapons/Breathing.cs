using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathing : Weapon
{
    public float Radius;

    protected override void Attack()
    {
        base.Attack();

        GameObject slash = Instantiate(WeaponPrefab, transform.position, Quaternion.identity, transform);
        slash.transform.localScale = slash.transform.localScale * (2 * Radius);

        Collider2D[] collidersHit = Physics2D.OverlapCircleAll(transform.position, Radius);
        foreach (Collider2D e in collidersHit)
        {     
            if(e.gameObject.TryGetComponent<EnemyChase>(out EnemyChase eChase)) eChase.Hurt(WeaponData.Damage);
        }
    }

    public override void Upgrade()
    {
        base.Upgrade();

        if(WeaponData.Level < 5)
        {
            WeaponData.Level++;
        }
    }
}
