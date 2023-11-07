using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FairyDust : MonoBehaviour
{
    public float dmg;

    private void OnParticleCollision(GameObject other)
    {
        if(other.CompareTag("Enemy"))
        {
            other.GetComponent<Enemy>().Hurt(dmg);
        }
    }
}
