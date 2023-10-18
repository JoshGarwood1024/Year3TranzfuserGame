using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    public List<GameObject> attackRadius = new List<GameObject>();
    //List<Weapon> currentWeapons;

    public GameObject slashPrefab;

    //will be based on weapon reset time
    float attackTime = 1.5f;
    float timer;

    public float damage = 25;

    public bool active;

    // Start is called before the first frame update
    void Start()
    {
        timer = attackTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0 && active)
        {
            Attack();
            timer = attackTime;
        } else
        {
            timer -= Time.deltaTime;
        }
    }

    public void EnemyDied(GameObject e)
    {
        if(attackRadius.Contains(e))
        {
            attackRadius.Remove(e);
        }
    }

    public void Attack()
    {
        GameObject slash = Instantiate(slashPrefab, transform.position, Quaternion.identity, transform);
        slash.transform.localScale = slash.transform.localScale * (2 * GetComponent<CircleCollider2D>().radius);

        foreach (GameObject e in attackRadius)
        {
            //replace with (Weapon.damage)
            e.GetComponent<EnemyChase>().Hurt(damage);
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy" && Mathf.Abs(Vector2.Distance(collision.gameObject.transform.position,transform.position)) < 2 * GetComponent<CircleCollider2D>().radius)
        {
            attackRadius.Add(collision.gameObject);
        }
        
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            attackRadius.Remove(collision.gameObject);
        }
        
    }
}
