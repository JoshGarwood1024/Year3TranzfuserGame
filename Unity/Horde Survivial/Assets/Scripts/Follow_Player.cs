using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Player : MonoBehaviour
{
    public Transform player;         
    public float floatSpeed = 2.0f;    
    public float floatDistance = 2.0f;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (player == null)
        {
            Debug.LogError("Player reference not set in the inspector!");
            return;
        }

      
        Vector3 targetPosition = player.position - player.forward * floatDistance;

      
        transform.position = Vector3.Lerp(transform.position, targetPosition, floatSpeed * Time.deltaTime);
    }
}

