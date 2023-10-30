using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Balloon : MonoBehaviour
{
    [HideInInspector]
    public float Damage;
    
    public Sprite ExplodedSprite;

    private float time = 0.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy"))
        {
            collision.gameObject.GetComponent<EnemyChase>().Hurt(Damage);

            Collider2D[] surroundingEnemies = Physics2D.OverlapCircleAll(transform.position, 2);

            foreach (Collider2D enemy in surroundingEnemies)
            {
                if (enemy.CompareTag("Enemy"))
                {
                    enemy.GetComponent<EnemyChase>().Hurt(Damage);
                }

            }

            StartCoroutine(Explosion());
        }
    }

    IEnumerator Explosion()
    {
        GetComponent<SpriteRenderer>().sprite = ExplodedSprite;

        yield return new WaitForSeconds(0.3f);

        Destroy(gameObject);
    }

    private void Update()
    {
        if (time > 5)
        {
            Destroy(gameObject);
        }

        time += Time.deltaTime;
    }
}
