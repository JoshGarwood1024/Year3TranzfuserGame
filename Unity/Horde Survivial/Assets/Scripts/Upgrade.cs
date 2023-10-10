using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Upgrade : MonoBehaviour
{

    public virtual void Use() { }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}

public class BreathOfTheWild : Upgrade
{
    public override void Use()
    {
        base.Use();
    }
} 
