using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PetsLoop : MonoBehaviour
{
    public string playerTag = "Player"; // Set the tag of your player GameObject
    public float floatRadius = 2f;
    public float floatSpeed = 2f;

    private Vector3 originalPosition;

    void Start()
    {
        // Store the original position of the GameObject
        originalPosition = transform.position;
    }

    void Update()
    {
        // Find the player GameObject using the specified tag
        GameObject player = GameObject.FindWithTag(playerTag);

        // Ensure that the player GameObject is found
        if (player != null)
        {
            // Calculate the offset from the original position
            float xOffset = Mathf.Sin(Time.time * floatSpeed) * floatRadius;
            float yOffset = Mathf.Cos(Time.time * floatSpeed) * floatRadius;

            // Move the GameObject around the player in an elliptical motion
            transform.position = player.transform.position + new Vector3(xOffset, yOffset, 0f);
        }
        else
        {
            Debug.LogWarning("Player with tag '" + playerTag + "' not found!");
        }
    }
}
