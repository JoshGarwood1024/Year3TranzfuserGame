using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health_Pickup : MonoBehaviour
{
   

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerHealth.PHealth += 20;
            Destroy(this.gameObject);
        }
    }


}
