using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Meditation : Weapon
{
    protected override void Start()
    {
        base.Start();   
    }

    protected override void Update()
    {
        base.Update();
    }

    protected override void Attack()
    {
        base.Attack();

        for(int i = 0; i < 4; i++)
        {
            StartCoroutine(SpawnTree());
        }
    }

    IEnumerator SpawnTree()
    {
        yield return new WaitForSeconds(Random.Range(0.01f, 0.3f));

        Vector3 offset = new Vector3(Random.Range(-3, 3), Random.Range(-3, 3));
        GameObject tree = Instantiate(WeaponPrefab, transform.position + offset, Quaternion.identity);
        tree.GetComponent<TreeGrowth>().SetDamage(WeaponData.Damage);
    }
}
