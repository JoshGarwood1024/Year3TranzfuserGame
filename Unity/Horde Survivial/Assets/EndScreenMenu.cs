using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class EndScreenMenu : MonoBehaviour
{
    public TextMeshProUGUI LevelText;
    
    void Start()
    {
        
    }

  
    void Update()
    {
        
    }

    public void OpenMenu()
    {
        gameObject.SetActive(true);
        int level = PlayerData.Instance.gameObject.GetComponent<LevelSystem>().level;
        PlayerData.Instance.gameObject.GetComponent<CameraShake>().shakeAmount = 0;
        LevelText.text = level.ToString();
        Time.timeScale = 0f;
    }

    public void LoadAgain()
    {
        SceneManager.LoadScene("MainGame");
        PermCurrency.PermCur = 0;
        ScoreScript.scoreValue = 0;
        Time.timeScale = 1f;
    }

    public void LoadMenu()
    {        
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex - 1);
        Time.timeScale = 1f;
        ScoreScript.scoreValue = 0;
        PermCurrency.PermCur = 0;
    }


    public void Quit()
    {
        Debug.Log("Quit");
        Application.Quit();
    }
}
