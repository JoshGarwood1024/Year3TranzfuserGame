using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;

    private float time = 0.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<Enemy>().Hurt(Damage);
            Destroy(gameObject);
        }
    }


    private void Update()
    {
        if(time > 5)
        {
            Destroy(gameObject);
        }

        time += Time.deltaTime;
    }
}
