using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject WeaponPrefab;
    public WeaponSO WeaponData;

    public bool active;
    float currentCooldown;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentCooldown = WeaponData.Cooldown;
    }

    // Update is called once per frame
    protected virtual void Update()
    {
        currentCooldown -= Time.deltaTime;
        if(currentCooldown <= 0 && active)
        {
            Attack();       
        }
    }

    protected virtual void Attack()
    {
        currentCooldown = WeaponData.Cooldown;
    }

    protected virtual void Upgrade() 
    {
        if(WeaponData.Level < 5) WeaponData.Level++;
    }

    protected virtual void Activate()
    {
        active = true;
        WeaponData.Level = 1;
    }
}

