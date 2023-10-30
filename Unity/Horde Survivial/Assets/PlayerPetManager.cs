using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPetManager : MonoBehaviour
{
    public GameObject pet1;
    public GameObject pet2;
    public GameObject pet3;

    static bool pet4 = false;
    static bool pet5 = false;
    static bool pet6 = false;


    public void LoadGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    //    pet4 = true;
    }
  //  public void Update()
  //  {
     //   if (pet4 = true)
       // {
       //     pet1.SetActive.(true);
       // }
   // }
}




