using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrowth : MonoBehaviour
{

    Vector3 fullSize;
    float damage = 0;

    private void Start()
    {
        float randomScale = Random.Range(3, 5);
        fullSize = new Vector3(randomScale, randomScale);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.localScale != fullSize)
        {
            transform.localScale = Vector3.Lerp(transform.localScale, fullSize, Time.deltaTime * 2);
        }
    }

    public void SetDamage(float dmg)
    {
        damage = dmg;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == "Enemy" && !collision.isTrigger)
        {
            collision.gameObject.GetComponent<Enemy>().Hurt(damage);
        }
    }
}
