using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class PopUpText : MonoBehaviour
{
    public GameObject popUpText;

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Trigger"))
        {
            popUpText.GetComponent<TextMeshPro>().text = "Press 'E'";
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Trigger"))
        {
            popUpText.GetComponent<TextMeshPro>().text = "";
        }
    }
}
