using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerPetManager : MonoBehaviour
{
    private void Start()
    {
        GetComponent<SpriteRenderer>().sprite = PlayerManager.Instance.GetPetSprite();   
    }
}




