using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerData : MonoBehaviour
{
    public float DamageBuff = 0;
    public float HealthBuff = 0;
    public float SpeedBuffMultiplier;
    public float PickupRangeBuffMultiplier;

    public TimeManager timeManager; //refererncing this for high score when player dies - CL
    public Image healthbar;

    public GameObject UFOMessedUp;

    private float CurrentHealth;
    public float StartHealth;
    private bool isInvincible = false;
    [SerializeField] private float invincibilityDurationSeconds;

    public Animator animator;

    public GameObject EndMenu;

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
        CurrentHealth = StartHealth + HealthBuff;
        UFOMessedUp.GetComponent<TimeManager>();
    }
    private void Update()
    {
        healthbar.gameObject.transform.parent.transform.rotation = Quaternion.identity;
    }

    public void UpdateHealthBar()
    {
        healthbar.fillAmount = CurrentHealth / StartHealth + HealthBuff;
    }

    public void DecreaseHealth(float health)
    {
        if (isInvincible) return;

        if (CurrentHealth - health <= 0)
        {
            GameManager.Instance.UpdateGameState(GameState.Lose);
            EndMenu.GetComponent<EndScreenMenu>().OpenMenu();
            PlayerManager.Instance.Save();
            timeManager.SetTotalTimeSurvived();
            if (PlayerPrefs.GetInt("Highscore") > timeManager.gameTime)
            {
                timeManager.SetHighscore();
            }

        } else
        {
            CurrentHealth -= health;
            StartCoroutine(BecomeTemporarilyInvincible());
        }

        UpdateHealthBar();
    }

    public void IncreaseHealth(float health)
    {
        if(CurrentHealth + health > StartHealth + HealthBuff)
        {
            CurrentHealth = StartHealth + HealthBuff;
        } else
        {
            CurrentHealth += health;
        }

        UpdateHealthBar();
    }
    private IEnumerator BecomeTemporarilyInvincible()
    {
        animator.SetBool("IsHit", true);
        Debug.Log("Player turned invincible!");
        isInvincible = true;

        yield return new WaitForSeconds(invincibilityDurationSeconds);

        isInvincible = false;
        Debug.Log("Player is no longer invincible!");
        animator.SetBool("IsHit", false);
    }
}

