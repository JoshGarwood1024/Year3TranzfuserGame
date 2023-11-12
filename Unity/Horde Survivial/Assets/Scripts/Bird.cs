using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bird : MonoBehaviour
{
    private PlayerMovement Movement;

    // Start is called before the first frame update
    void Start()
    {
        Movement = GetComponent<PlayerMovement>();

    }

    // Update is called once per frame
    void Update()
    {
        if (Movement != null)
        {
            float originalSpeed = Movement.moveSpeed;

            float newSpeed = originalSpeed * 2;

            Debug.Log("Original Speed: " + originalSpeed);
            Debug.Log("New Speed: " + newSpeed);
        }
    }
}
