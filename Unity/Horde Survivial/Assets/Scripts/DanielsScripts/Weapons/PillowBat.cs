using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowBat : Weapon     
{

    private GameObject pillowBat;

    protected override void Attack()
    {
        base.Attack();

        if (MaxLevel)
        {
            Collider2D[] collidersHit = Physics2D.OverlapCircleAll(transform.position, 3);
            foreach (Collider2D e in collidersHit)
            {
                if (e.gameObject.TryGetComponent<Enemy>(out Enemy enemy) && !e.isTrigger) enemy.Hurt(30 + DamageIncrease);
            }
        }

        pillowBat = Instantiate(WeaponPrefab, transform.position + new Vector3(2.5f, 0, 0), WeaponPrefab.transform.rotation, transform);
        pillowBat.GetComponent<HurtEnemyOnTrigger>().Damage = WeaponData.Damage + DamageIncrease;
        StartCoroutine(Dissapear());
    }

    protected override void Update()
    {
        base.Update();

        if(pillowBat)
        {
            pillowBat.transform.RotateAround(transform.position, new Vector3(0, 0, 1), 540 * Time.deltaTime);
        }
    }

    public override void Upgrade(int level)
    {
        base.Upgrade(level);

        DamageIncrease += 5;
    }

    IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(1f);

        Destroy(pillowBat);

    }
}
