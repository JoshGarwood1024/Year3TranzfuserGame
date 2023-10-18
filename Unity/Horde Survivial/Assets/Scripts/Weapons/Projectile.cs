using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : Weapon
{

    public List<Transform> nearbyEnemies = new List<Transform>();

    protected override void Start()
    {
        base.Start();
        //active = false;
    }

    protected override void Attack()
    {
        base.Attack();

        if(nearbyEnemies.Count > 0)
        {
            Vector2 aimDirection = GetClosestEnemy().position - transform.position;
            float aimAngle = Mathf.Atan2(aimDirection.y, aimDirection.x) * Mathf.Rad2Deg - 90f;

            GameObject bullet = Instantiate(prefab, transform.position, Quaternion.identity);

            bullet.transform.Rotate(0,0,aimAngle - 5);
            bullet.GetComponent<Bullet>().Damage = damage;
            bullet.GetComponent<Rigidbody2D>().AddForce((GetClosestEnemy().position - transform.position) * 10, ForceMode2D.Impulse);
        }
    }

    public void EnemyDied(GameObject e)
    {
        if (nearbyEnemies.Contains(e.transform))
        {
            nearbyEnemies.Remove(e.transform);
        }
    }

    public void activate()
    {
        active = true;
    }

    Transform GetClosestEnemy()
    {
        Transform bestTarget = null;
        float closestDistanceSqr = Mathf.Infinity;
        Vector3 currentPosition = transform.position;
        foreach (Transform potentialTarget in nearbyEnemies)
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

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!nearbyEnemies.Contains(collision.gameObject.transform) && collision.gameObject.tag == "Enemy")
        {
            nearbyEnemies.Add(collision.gameObject.transform);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if(nearbyEnemies.Contains(collision.gameObject.transform))
        {
            nearbyEnemies.Remove(collision.gameObject.transform);
        }
    }
}
