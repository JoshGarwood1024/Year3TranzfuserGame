using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    List<GameObject> attackRadius = new List<GameObject>();
    //List<Weapon> currentWeapons;

    public GameObject slashPrefab;

    //will be based on weapon reset time
    float attackTime = 1.5f;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        timer = attackTime;
    }

    // Update is called once per frame
    void Update()
    {
        if(timer <= 0)
        {
            Attack();
            timer = attackTime;
        } else
        {
            timer -= Time.deltaTime;
        }
    }

    public void Attack()
    {
        Debug.Log("Attack");

        GameObject slash = Instantiate(slashPrefab, transform.position, Quaternion.identity, transform);
        slash.transform.localScale = slash.transform.localScale * (2 * GetComponent<CircleCollider2D>().radius);

        foreach (GameObject e in attackRadius)
        {
            //replace with (Weapon.damage)
            e.GetComponent<EnemyChase>().Hurt(30);
            
        }

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
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
