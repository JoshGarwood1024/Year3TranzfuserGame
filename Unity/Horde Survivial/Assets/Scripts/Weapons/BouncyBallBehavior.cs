using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBallBehavior : MonoBehaviour
{
    float hitCount = 0;
    public float Damage;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitCount++;

        collision.gameObject.GetComponent<Enemy>().Hurt(Damage);

        if (hitCount >= 3) Destroy(gameObject);
    }
}
