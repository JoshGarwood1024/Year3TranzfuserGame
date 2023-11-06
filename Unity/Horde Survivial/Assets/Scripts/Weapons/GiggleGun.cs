using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GiggleGun : Weapon
{
    protected override void Attack()
    {
        base.Attack();

        GameObject laughingFace = Instantiate(WeaponPrefab, transform.position, Quaternion.identity);

        Vector3 playerDir = GetComponentInParent<SpriteRenderer>().flipX ? Vector3.left : Vector3.right;

        Vector3 randDir = Quaternion.Euler(0, 0, Random.Range(-30f, 30f)) * playerDir.normalized;

        laughingFace.GetComponent<Rigidbody2D>().velocity = randDir * 15;

        laughingFace.GetComponent<HurtEnemyOnTrigger>().Damage = WeaponData.Damage;
    }
}
