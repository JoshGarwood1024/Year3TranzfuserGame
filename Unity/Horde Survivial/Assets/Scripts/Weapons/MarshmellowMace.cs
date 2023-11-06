using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MarshmellowMace : Weapon
{
    GameObject mace;
    public override void Activate()
    {
        base.Activate();

        mace = Instantiate(WeaponPrefab, transform.position + new Vector3(1.7f, 0 ,0), WeaponPrefab.transform.rotation, transform);
        mace.GetComponent<HurtEnemyOnTrigger>().Damage = WeaponData.Damage;
    }

    protected override void Update()
    {
        base.Update();

        if(Input.GetKeyDown(KeyCode.J))
        {
            Activate();
        }

        if(mace)
        {
            mace.transform.RotateAround(transform.position, new Vector3(0,0,1), 180 * Time.deltaTime);
        }
    }
}
