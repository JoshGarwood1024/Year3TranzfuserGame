using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum StartingClass
{ 
    Meditation,
    Breathing,
    Exercise,
    Social
}

public enum Pet
{ 
    Dog,
    Cat,
    Bird
}


public class PlayerManager : MonoBehaviour
{
    public static PlayerManager Instance;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    private void Start()
    {
        PlayersClass = StartingClass.Breathing;
    }

    public StartingClass PlayersClass { get; private set; }
    public Pet PlayersPet { get; private set; }

    public void SetStartingClass(StartingClass sc)
    {
        PlayersClass = sc;
    }

    public void SetPet(Pet p)
    {
        PlayersPet = p;
    }
}
