using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaughingFace : MonoBehaviour
{
    public bool Active = false;
    public float Dmg;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Enemy") && !collision.isTrigger)
        {
            collision.GetComponent<EnemyChase>().Hurt(Dmg);
            if(Active) Explode(collision);
            Destroy(gameObject);
        }
    }

    void Explode(Collider2D col)
    {
        Collider2D[] surroundingEnemies = Physics2D.OverlapCircleAll(transform.position, 2);

        foreach (Collider2D enemy in surroundingEnemies)
        {
            if (enemy.CompareTag("Enemy"))
            {
                enemy.GetComponent<EnemyChase>().Hurt(10);
            }
        }

        for (int i = 0; i < 4; i++) {
            GameObject laughingFace = Instantiate(gameObject, transform.position, Quaternion.identity);
            Vector3 randDir = Random.insideUnitCircle;
            laughingFace.transform.localScale *= 0.3f;
            laughingFace.GetComponent<Rigidbody2D>().velocity = randDir * 10;
            laughingFace.GetComponent<LaughingFace>().Dmg = Mathf.Round(Dmg / 2);
            laughingFace.GetComponent<LaughingFace>().Active = false;
        }
    }
}