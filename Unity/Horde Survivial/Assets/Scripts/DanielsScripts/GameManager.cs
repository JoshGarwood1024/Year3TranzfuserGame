using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public GameState State;

    public static event Action<GameState> OnGameStateChanged;

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
    // Start is called before the first frame update
    void Start()
    {
        switch (PlayerManager.Instance.PlayersPet)
        {
            case Pet.Dog:
                PlayerManager.Instance.SetPet("Dog");
                break;
            case Pet.Cat:
                PlayerManager.Instance.SetPet("Cat");
                break;
            case Pet.Bird:
                PlayerManager.Instance.SetPet("Bird");
                break;
        }
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void UpdateGameState(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Playing:
                Time.timeScale = 1.0f;
                break;
            case GameState.Paused:
                Time.timeScale = 1.0f;
                break;
            case GameState.Win:
                break;
            case GameState.Lose:
                break;
        }

        OnGameStateChanged?.Invoke(newState);
    }
}

public enum GameState { 
    Playing,
    Paused,
    Win,
    Lose
}

