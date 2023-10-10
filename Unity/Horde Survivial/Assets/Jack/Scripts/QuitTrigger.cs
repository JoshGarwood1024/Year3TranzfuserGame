using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuitTrigger : MonoBehaviour
{
    private bool inTrigger = false;

    void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            Debug.Log("Quit");
            Application.Quit();
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            inTrigger = false;
        }
    }
}

