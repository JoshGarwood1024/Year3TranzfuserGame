using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyChase : Enemy
{
    Rigidbody2D rb;
    public float speed;

    bool chasing;

    public override void Start()
    {
        base.Start();

        rb = GetComponent<Rigidbody2D>();

        chasing = true;
    }

    private void FixedUpdate()
    {
        if(chasing)
        {
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();

            rb.velocity = direction * speed;
        }

    }

    public override void Hurt(float dmg)
    {
        base.Hurt(dmg);

        Vector3 dir = player.transform.position - transform.position;
        dir.Normalize();

        StartCoroutine(Knockback());

        rb.velocity = Vector2.zero;
        rb.AddForce(-dir * 2000, ForceMode2D.Impulse);
    }

    IEnumerator Knockback()
    {
        chasing = false;
        yield return new WaitForSeconds(0.4f);
        chasing = true;
    }
}
