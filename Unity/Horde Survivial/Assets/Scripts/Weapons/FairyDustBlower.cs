using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyDustBlower : Weapon
{

    protected override void Attack()
    {
        base.Attack();

        GameObject p = Instantiate(WeaponPrefab, transform);
        p.GetComponent<FairyDust>().dmg = WeaponData.Damage + DamageIncrease;
    }

}
