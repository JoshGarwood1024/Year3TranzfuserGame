using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBalls : Weapon
{

    int numOfBalls;

    protected override void Start()
    {
        base.Start();

        numOfBalls = 1;
    }
    protected override void Attack()
    {
        base.Attack();

        for (int i = 0; i < numOfBalls; i++)
        {
            GameObject bouncyBall = Instantiate(WeaponPrefab, transform.position, WeaponPrefab.transform.rotation);

            Vector2 randDir = Random.insideUnitCircle * 10;
            bouncyBall.GetComponent<Rigidbody2D>().AddRelativeForce(randDir, ForceMode2D.Impulse);
            bouncyBall.GetComponent<BouncyBallBehavior>().Damage = WeaponData.Damage + DamageIncrease;
            if(MaxLevel) bouncyBall.GetComponent<BouncyBallBehavior>().maxLevel = true;
        }
    }

    public override void Upgrade(int level)
    {
        base.Upgrade(level);

        DamageIncrease += 10;
        numOfBalls++;
    }
}
