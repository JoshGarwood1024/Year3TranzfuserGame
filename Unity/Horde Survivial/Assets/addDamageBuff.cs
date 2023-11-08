using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class addDamageBuff : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerData.Instance.DamageBuff += 2;
            Destroy(this.gameObject);
        }
    }
}
