using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dog : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        PlayerData.Instance.DamageBuff += 10;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
