using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TreeGrowth : MonoBehaviour
{

    public Vector3 fullSize;
    float damage = 0;

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
        if(collision.tag == "Enemy")
        {
            collision.gameObject.GetComponent<EnemyChase>().Hurt(damage);
        }
    }
}
