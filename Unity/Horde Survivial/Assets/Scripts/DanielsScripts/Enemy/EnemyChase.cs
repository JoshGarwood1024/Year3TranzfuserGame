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

    protected override void Update()
    {
        base.Update();

        if(PlayerData.Instance.gameObject.transform.position.x < transform.position.x)
        {
            GetComponent<SpriteRenderer>().flipX = true;
        } else
        {
            GetComponent<SpriteRenderer>().flipX = false; 
        }
    }

    public override void Attack(GameObject p)
    {
        base.Attack(p);

        StartCoroutine(Knockback());
    }
    public override void Hurt(float dmg)
    {
        base.Hurt(dmg);

        StartCoroutine(Knockback());
    }

    IEnumerator Knockback()
    {
        chasing = false;

        Vector3 dir = player.transform.position - transform.position;
        dir.Normalize();

        rb.velocity = Vector2.zero;
        rb.AddForce(-dir * 1000, ForceMode2D.Impulse);

        yield return new WaitForSeconds(0.4f);
        chasing = true;
    }
}
