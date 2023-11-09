using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PopUpTrigger : MonoBehaviour
{
    public GameObject popUp;
    private bool inTrigger = false;

    private void Update()
    {
        if (inTrigger && Input.GetKeyDown(KeyCode.E))
        {
            popUp.SetActive(true);
            PauseGame();
// Callum, this is to pause the game when options is on
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
    void PauseGame()
    {
        Time.timeScale = 0;
    }
}
