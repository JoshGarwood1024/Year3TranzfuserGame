using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ExplodeOnTrigger : MonoBehaviour
{
    public float dmg;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Collider2D[] cols = Physics2D.OverlapCircleAll(transform.position, 3);
        foreach(Collider2D col in cols)
        {
            if (col.TryGetComponent<Enemy>(out Enemy e) && !col.isTrigger) e.Hurt(dmg);
        }
    }
}
