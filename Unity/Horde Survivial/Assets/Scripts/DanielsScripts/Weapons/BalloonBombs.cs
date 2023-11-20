using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class BalloonBombs : Weapon
{

    public float Radius;
    float bombs;

    protected override void Start()
    {
        base.Start();

        bombs = 1;
    }

    protected override void Attack()
    {
        base.Attack();

        List<Collider2D> ignoreList = new List<Collider2D>();
        
        for(int i = 0; i < bombs; i++) {
            Collider2D closestEnemy = ClosestEnemy(ignoreList);
            ignoreList.Add(closestEnemy);

            if (!closestEnemy) return;

            Vector2 aimDirection = closestEnemy.transform.position - transform.position;

            GameObject balloon = Instantiate(WeaponPrefab, transform.position, Quaternion.identity);

            balloon.GetComponent<Rigidbody2D>().AddForce(aimDirection, ForceMode2D.Impulse);
            balloon.GetComponent<Balloon>().Damage = WeaponData.Damage + DamageIncrease + PermDamageIncrease;
            balloon.GetComponent<Balloon>().ExplodeRadius = MaxLevel ? 4 : 2;
        }
    }

    Collider2D ClosestEnemy(List<Collider2D> ignore)
    {
        Collider2D[] closestEnemies = Physics2D.OverlapCircleAll(transform.position, Radius);

        foreach (Collider2D closestEnemy in closestEnemies)
        {
            if (closestEnemy.CompareTag("Enemy") && !ignore.Contains(closestEnemy))
            {
                return closestEnemy;
            }
        }

        return null;
    }
    public override void Upgrade(int level)
    {
        base.Upgrade(level);

        DamageIncrease += 10;
        bombs++;
    }

    public override void ApplyPermUpgrade(int level)
    {
        base.ApplyPermUpgrade(level);

        for (int i = 0; i < level; i++)
        {
            CooldownReduction += 0.25f;
            PermDamageIncrease += 25;
        }
    }

}
