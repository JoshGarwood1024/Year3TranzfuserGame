using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class resumegame : MonoBehaviour
{
    public GameObject Bird;
    public GameObject Cat;
    public GameObject Dog;
    public GameObject PetMenu;



    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void back()
    {
        PetMenu.SetActive(false);
    }

    public void ResumeGame()
    {
        Time.timeScale = 1;
    }

    public void DogPet()
    {
        Dog.SetActive(true);
        Bird.SetActive(false);
        Cat.SetActive(false);
    }

    public void Catpet()
    {
        Dog.SetActive(false);
        Bird.SetActive(false);
        Cat.SetActive(true); ;
    }
    public void Birdpet()
    {
        Dog.SetActive(false);
        Bird.SetActive(true);
        Cat.SetActive(false);
    }
}
