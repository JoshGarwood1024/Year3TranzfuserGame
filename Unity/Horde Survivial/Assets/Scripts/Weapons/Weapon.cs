using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{

    public GameObject prefab;
    public float damage;
    public float cooldown;

    public bool active;
    float currentCooldown;

    // Start is called before the first frame update
    protected virtual void Start()
    {
        currentCooldown = cooldown;
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
        currentCooldown = cooldown;
    }

    public virtual void Activate()
    {

    }
}

