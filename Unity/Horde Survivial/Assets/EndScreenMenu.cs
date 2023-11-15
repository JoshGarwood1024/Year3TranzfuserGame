using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndScreenMenu : MonoBehaviour
{
    
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    public void LoadAgain()
    {
        SceneManager.LoadScene("MainGame");
    }

    public void LoadMenu()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - 1);
    }

    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
