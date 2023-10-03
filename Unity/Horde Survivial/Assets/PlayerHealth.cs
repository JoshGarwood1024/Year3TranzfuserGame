using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public static float PHealth = 100;
    public float startMHealth;
    public Image heathbar;



    // Start is called before the first frame update
    void Start()
    {
        PHealth = startMHealth;

    }
    // Update is called once per frame
    void Update()
    {
        heathbar.fillAmount = PHealth / startMHealth;

        if (PHealth <= 0)
        {
            //SceneManager.LoadScene("DeadScene");

            //PHealth = 100;
            // Destroy(gameObject);
            SceneManager.LoadScene(0);
        }
    }
}