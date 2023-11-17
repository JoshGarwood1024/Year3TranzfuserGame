using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follow_Player : MonoBehaviour
{
    public string playerTag = "Pets"; // Set the tag of your player GameObject
    public float followSpeed = 5f;

    void Update()
    {
        // Find the player GameObject using the specified tag
        GameObject player = GameObject.FindWithTag(playerTag);

        // Ensure that the player GameObject is found
        if (player != null)
        {
            // Calculate the direction from the current position to the player's position
            Vector3 directionToPlayer = player.transform.position - transform.position;

            // Normalize the direction vector to ensure consistent movement speed in all directions
            directionToPlayer.Normalize();

            // Move towards the player
            transform.position += directionToPlayer * followSpeed * Time.deltaTime;
        }
        else
        {
            Debug.LogWarning("Player with tag '" + playerTag + "' not found!");
        }
    }
}


