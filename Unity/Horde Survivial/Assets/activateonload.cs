using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class activateonload : MonoBehaviour
{

    public GameObject fadein; 


    // Start is called before the first frame update
    void Start()
    {
        fadein.SetActive(true);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
