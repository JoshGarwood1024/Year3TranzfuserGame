using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyDustBlower : Weapon
{

    protected override void Attack()
    {
        base.Attack();

        GameObject p = Instantiate(WeaponPrefab, transform);
        p.GetComponent<FairyDust>().dmg = WeaponData.Damage;

/*        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 4);
        Vector3 enemyToCollider;
        float dot;

        foreach(Collider2D collider in cols)
        {
            if(collider.CompareTag("Enemy"))
            {
                enemyToCollider = (collider.transform.position - transform.position).normalized;
                dot = Vector3.Dot(enemyToCollider, transform.right);
                if (dot >= Mathf.Cos(20))
                {
                    collider.GetComponent<EnemyChase>().Hurt(WeaponData.Damage);
                }
            }
        }*/
    }

}
