using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;
    public GameObject scoreText;

    private float time = 0.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyChase>().Hurt(Damage);
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
