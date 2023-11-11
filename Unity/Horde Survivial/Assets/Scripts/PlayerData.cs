using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public float DamageBuff = 0;
    public float HealthBuff = 0;

    public Image healthbar;

    private float CurrentHealth;
    public float StartHealth;

    public static PlayerData Instance { get; private set; }

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

    private void Start()
    {
        CurrentHealth = StartHealth;    
    }
    private void Update()
    {
        healthbar.gameObject.transform.parent.transform.rotation = Quaternion.identity;
    }

    public void UpdateHealthBar()
    {
        healthbar.fillAmount = CurrentHealth / StartHealth;
    }

    public void DecreaseHealth(float health)
    {
        if(CurrentHealth - health <= 0)
        {
            GameManager.Instance.UpdateGameState(GameState.Lose);
            SceneManager.LoadScene(0);
        } else
        {
            CurrentHealth -= health;
        }

        UpdateHealthBar();
    }

    public void IncreaseHealth(float health)
    {
        if(CurrentHealth + health > StartHealth)
        {
            CurrentHealth = StartHealth;
        } else
        {
            CurrentHealth += health;
        }

        UpdateHealthBar();
    }
}

