using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SockPuppetSling : Weapon
{
    protected override void Attack()
    {
        base.Attack();

        GameObject sockPuppet = Instantiate(WeaponPrefab, transform.position, transform.rotation);
        sockPuppet.GetComponent<Rigidbody2D>().velocity = Random.insideUnitCircle * 15;
        sockPuppet.GetComponent<HurtEnemyOnTrigger>().Damage = WeaponData.Damage;
    }
}

