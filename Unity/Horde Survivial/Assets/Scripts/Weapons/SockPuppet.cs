using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SockPuppet : MonoBehaviour
{
    //MAX LEVEL SOCK PUPPET SCRIPT

    Transform target;
    bool isAttacking = false;

    float attackDelay = 2f;
    float spawnTime = 15f;
    float knockbackForce = 5f;
    float attackRange = 2f;
    public float attackDmg;
    // Start is called before the first frame update
    void Start()
    {
        StartAttacking();
        Destroy(gameObject, spawnTime);
    }

    private void Update()
    {
        if(isAttacking)
        {
            StartCoroutine(Attack());
        }
    }
    void StartAttacking()
    {
        isAttacking = true;
        target = FindNearestEnemy();
    }

    
    IEnumerator Attack()
    {
        if(target == null)
        {
            target = FindNearestEnemy();
            yield break;
        }

        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
        transform.position = Vector3.MoveTowards(transform.position, target.position, Time.deltaTime * 4);

        if (Vector3.Distance(transform.position, target.position) < attackRange)
        {
            Debug.Log("CLOSE TO ENEMY");
            target.gameObject.GetComponent<Enemy>().Hurt(attackDmg);

            Vector2 knockbackDirection = (transform.position - target.position).normalized;
            GetComponent<Rigidbody2D>().AddForce(knockbackDirection * knockbackForce, ForceMode2D.Impulse);

            target = null;
            isAttacking = false;

            yield return new WaitForSeconds(attackDelay);
            StartAttacking();
        }
    }

    Transform FindNearestEnemy()
    {
        Collider2D[] allColliders = Physics2D.OverlapCircleAll(transform.position, 100);
        List<Transform> enemies = new List<Transform>();

        foreach (Collider2D col in allColliders)
        {
            if (col.CompareTag("Enemy"))
            {
                enemies.Add(col.gameObject.transform);
            }
        }

        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in enemies)
        {
            Vector3 directionToTarget = potentialTarget.position - currentPosition;
            float dSqrToTarget = directionToTarget.sqrMagnitude;
            if (dSqrToTarget < closestDistanceSqr)
            {
                closestDistanceSqr = dSqrToTarget;
                bestTarget = potentialTarget;
            }
        }

        return bestTarget;
    }
}

