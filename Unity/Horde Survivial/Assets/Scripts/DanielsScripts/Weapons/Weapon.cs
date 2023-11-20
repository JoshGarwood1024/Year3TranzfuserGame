using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    
    public GameObject WeaponPrefab;
    public WeaponSO WeaponData;

    public bool active;
    float currentCooldown;

    public bool MaxLevel;
    public int currentLevel;

    //affected by upgrades
    public float DamageIncrease = 0;
    public float CooldownReduction;
    public float PermDamageIncrease = 0;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentCooldown = WeaponData.Cooldown;
        currentLevel = 0;
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

    public virtual void ApplyPermUpgrade(int level)
    {

    }

    protected virtual void Attack()
    {
        currentCooldown = WeaponData.Cooldown - CooldownReduction;
    }

    public virtual void Upgrade(int level) 
    {
        if (level >= 5) MaxLevel = true;

        currentLevel++;
    }

    public virtual void Activate()
    {
        active = true;
    }
}

