using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SquareMove : MonoBehaviour
{
    public float moveSpeed = 2.0f; // Adjust the speed as needed
    public float moveDistance = 2.0f; // Adjust the distance the square should move

    private Vector3 initialPosition;
    private float moveDirection = 1; // 1 for right, -1 for left

    void Start()
    {
        initialPosition = transform.position;
    }

    void Update()
    {
        // Calculate the new position
        Vector3 newPosition = transform.position + Vector3.right * moveDirection * moveSpeed * Time.deltaTime;

        // Check if the square has moved the desired distance to the right or left
        if (Mathf.Abs(newPosition.x - initialPosition.x) >= moveDistance)
        {
            // Change direction
            moveDirection *= -1;
        }

        // Move the square
        transform.position = newPosition;
    }
}
