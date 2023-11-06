using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBalls : Weapon
{
    protected override void Attack()
    {
        base.Attack();

        GameObject bouncyBall = Instantiate(WeaponPrefab, transform.position, WeaponPrefab.transform.rotation);

        Vector2 randDir = Random.insideUnitCircle * 10;
        bouncyBall.GetComponent<Rigidbody2D>().AddRelativeForce(randDir, ForceMode2D.Impulse);
        bouncyBall.GetComponent<BouncyBallBehavior>().Damage = WeaponData.Damage;
    }
}
