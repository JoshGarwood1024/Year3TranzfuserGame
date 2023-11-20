using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BouncyBallBehavior : MonoBehaviour
{
    float hitCount = 0;
    public float Damage;
    public ParticleSystem fireTrail;
    public bool maxLevel = false;
    public float bounceAllowance;

    private void Start()
    {
        if(maxLevel)
        {
            fireTrail.Play();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        hitCount++;

        if(collision.gameObject.TryGetComponent<Enemy>(out Enemy e) && !collision.collider.isTrigger) e.Hurt(Damage);

        if (hitCount >= 3) Destroy(gameObject);
    }
}
