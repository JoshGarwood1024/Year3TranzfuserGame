using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class permCurrencyPickUp : MonoBehaviour
{

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            PlayerManager.Instance.PermCurrency += 1;
            Destroy(gameObject);
            UIManager.Instance.UpdateUI();
        }
    }
}
