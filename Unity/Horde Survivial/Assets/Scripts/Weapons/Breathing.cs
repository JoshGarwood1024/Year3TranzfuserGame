using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Breathing : Weapon
{
    public float Radius;

    protected override void Attack()
    {
        GameObject slash = Instantiate(WeaponPrefab, transform.position, Quaternion.identity, transform);
        slash.transform.localScale = slash.transform.localScale * (2 * Radius);

        Collider2D[] collidersHit = Physics2D.OverlapCircleAll(transform.position, Radius);
        foreach (Collider2D e in collidersHit)
        {
            if(e.gameObject.TryGetComponent<Enemy>(out Enemy enemy) && !e.isTrigger) enemy.Hurt(WeaponData.Damage + DamageIncrease);
        }

        base.Attack();
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
