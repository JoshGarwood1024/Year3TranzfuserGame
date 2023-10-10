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


    void OnTriggerEnter2D(Collider2D hitinfo)
    {
        LevelSystem levelSystem = hitinfo.GetComponent<LevelSystem>();
        if (levelSystem != null)
        {
            levelSystem.GainExperienceFlatRate(20);
            Destroy(gameObject);

        }

    }
}
