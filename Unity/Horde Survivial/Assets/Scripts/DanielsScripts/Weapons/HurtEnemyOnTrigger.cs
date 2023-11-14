using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HurtEnemyOnTrigger : MonoBehaviour
{
    public float Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") && !collision.isTrigger)
        {
            collision.GetComponent<Enemy>().Hurt(Damage);
        }
    }
}
