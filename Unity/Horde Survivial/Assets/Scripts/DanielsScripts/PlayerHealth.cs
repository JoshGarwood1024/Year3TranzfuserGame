using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerHealth : MonoBehaviour
{
    public float PHealth = 100;
    public float startMHealth;
    public Image healthbar;



    // Start is called before the first frame update
    void Start()
    {
        PHealth = startMHealth;

    }
    // Update is called once per frame
    void Update()
    {
        healthbar.gameObject.transform.parent.transform.rotation = Quaternion.identity;
        healthbar.gameObject.transform.parent.transform.position = transform.position - new Vector3(0, 1.3f);

        healthbar.fillAmount = PHealth / startMHealth;

        if (PHealth <= 0)
        {

            SceneManager.LoadScene(0);
        }
    }
}