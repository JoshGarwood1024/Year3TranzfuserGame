using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class resumegame : MonoBehaviour
{
    public GameObject Bird;
    public GameObject Cat;
    public GameObject Dog;
    public GameObject PetMenu;

    public TextMeshProUGUI permCurrencyText;

    private void OnEnable()
    {
        if (permCurrencyText) permCurrencyText.text = PlayerManager.Instance.PermCurrency.ToString();
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
