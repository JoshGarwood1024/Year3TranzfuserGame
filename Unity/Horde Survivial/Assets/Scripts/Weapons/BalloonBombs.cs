using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalloonBombs : Weapon
{

    public float Radius;

    protected override void Start()
    {
        base.Start();
    }

    protected override void Attack()
    {
        base.Attack();

        Collider2D[] closestEnemies = Physics2D.OverlapCircleAll(transform.position, Radius);

        foreach (Collider2D closestEnemy in closestEnemies)
        {
            if(closestEnemy.CompareTag("Enemy"))
            {
                Vector2 aimDirection = closestEnemy.transform.position - transform.position;

                GameObject balloon = Instantiate(WeaponPrefab, transform.position, Quaternion.identity);

                balloon.GetComponent<Rigidbody2D>().AddForce(aimDirection, ForceMode2D.Impulse);
                balloon.GetComponent<Balloon>().Damage = WeaponData.Damage + DamageIncrease;

                return;
            }
        }
    }

    public override void Upgrade(int level)
    {
        base.Upgrade(level);
    }

}
