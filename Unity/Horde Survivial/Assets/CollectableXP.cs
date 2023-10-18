using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CollectableXP : MonoBehaviour
{


    // Start is called before the first frame update
    void Start()
    {
     
    }

    // Update is called once per frame
    void Update()
    {
     
    }



    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            LevelSystem levelSystem = collision.gameObject.GetComponent<LevelSystem>();
            if (levelSystem != null)
            {
                levelSystem.GainExperienceFlatRate(20);
                Destroy(gameObject);
            }
        }

    }
}
