using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class BottomText : MonoBehaviour
{
    public GameObject bottomText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bottomText.GetComponent<TextMeshPro>().text = this.gameObject.name;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            bottomText.GetComponent<TextMeshPro>().text = "";
        }
    }
}
