using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerManager : MonoBehaviour
{

    public List<Sprite> PetSprites;

    public static PlayerManager Instance;

    GameObject pet;

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

    public StartingClass PlayersClass { get; private set; }
    public Pet PlayersPet { get; private set; }
    private void Start()
    {
        PlayersClass = StartingClass.Breathing;

        pet = GameObject.Find("PlayersPet");

        PlayersPet = Pet.Dog;
        SetPet("Dog");
    }

    public void SetStartingClass(StartingClass sc)
    {
        PlayersClass = sc;
    }

    public Sprite GetPetSprite()
    {
        return PetSprites[(int)PlayersPet];
    }
    public void SetPet(string _pet)
    {
        if(!pet) pet = GameObject.Find("PlayersPet"); 

        switch (_pet)
        {
            case "Dog":
                pet.GetComponent<SpriteRenderer>().sprite = PetSprites[0];
                PlayersPet = Pet.Dog;
                break;
            case "Cat":
                pet.GetComponent<SpriteRenderer>().sprite = PetSprites[1];
                PlayersPet = Pet.Cat;
                break;
            case "Bird":
                pet.GetComponent<SpriteRenderer>().sprite = PetSprites[2];
                PlayersPet = Pet.Bird;
                break;
        }
    }
}

public enum StartingClass
{ 
    Meditation,
    Breathing,
    Exercise,
    Social
}

public enum Pet
{ 
    Dog = 0,
    Cat = 1,
    Bird = 2
}
