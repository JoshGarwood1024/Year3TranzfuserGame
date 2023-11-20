using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyDustBlower : Weapon
{

    protected override void Attack()
    {
        base.Attack();

        if(MaxLevel)
        {
            GameObject rp = Instantiate(WeaponPrefab, transform);
            rp.transform.Rotate(new Vector3(0, 180, 0));
            rp.GetComponent<FairyDust>().dmg = WeaponData.Damage + DamageIncrease + PermDamageIncrease;
        } 

        GameObject p = Instantiate(WeaponPrefab, transform);
        p.GetComponent<FairyDust>().dmg = WeaponData.Damage + DamageIncrease;
        if(PlayerData.Instance.gameObject.GetComponent<SpriteRenderer>().flipX) p.transform.Rotate(new Vector3(0, 180, 0));
    }

    public override void Upgrade(int level)
    {
        base.Upgrade(level);

        DamageIncrease += 10;
        CooldownReduction += 0.25f;
    }

    public override void ApplyPermUpgrade(int level)
    {
        base.ApplyPermUpgrade(level);

        for (int i = 0; i < level; i++)
        {
            CooldownReduction += 0.25f;
            PermDamageIncrease += 10;
        }
    }

}
