using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    private float time = 0.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);

        if(collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
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
