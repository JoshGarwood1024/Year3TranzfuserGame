using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerManger : MonoBehaviour
{
    public GameObject ClassMenu;
    public GameObject CharacterMenu;

    public void Boy()
    {
        ClassMenu.SetActive(true);
        CharacterMenu.SetActive(false);


    }
    public void Girl()
    {
        ClassMenu.SetActive(true);
        CharacterMenu.SetActive(false);

    }


}
