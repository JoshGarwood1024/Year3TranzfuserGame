using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PillowBat : Weapon     
{

    private GameObject pillowBat;

    protected override void Attack()
    {
        base.Attack();

        pillowBat = Instantiate(WeaponPrefab, transform.position + new Vector3(2.5f, 0, 0), WeaponPrefab.transform.rotation);
        pillowBat.GetComponent<HurtEnemyOnTrigger>().Damage = WeaponData.Damage;
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

    protected override void Upgrade()
    {
        base.Upgrade();
    }

    IEnumerator Dissapear()
    {
        yield return new WaitForSeconds(1f);

        Destroy(pillowBat);

    }
}
