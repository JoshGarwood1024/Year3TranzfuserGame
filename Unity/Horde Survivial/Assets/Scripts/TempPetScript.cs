using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TempPetScript : MonoBehaviour
{
    public GameObject pet1;
    public GameObject pet2;
    public GameObject pet3;
    public GameObject PetMenu;

    public void Dog()
    {
        pet1.SetActive(true);
        pet2.SetActive(false);
        pet3.SetActive(false);
        PetMenu.SetActive(false);
    }
    public void Cat()
    {
        pet1.SetActive(false);
        pet2.SetActive(true);
        pet3.SetActive(false);
        PetMenu.SetActive(false);
    }
    public void Bird()
    {
        pet1.SetActive(false);
        pet2.SetActive(false);
        pet3.SetActive(true);
        PetMenu.SetActive(false);
    }

}
