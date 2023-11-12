using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlueGem : MonoBehaviour
{

    Vector3 targetPos;

    private void Start()
    {
        targetPos = transform.position;
    }
    private void Update()
    {
        if (transform.position != targetPos)
        {
            transform.position = Vector3.Lerp(transform.position, targetPos, Time.deltaTime);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetPos = collision.transform.position;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            targetPos = transform.position;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            LevelSystem levelSystem = collision.gameObject.GetComponent<LevelSystem>();
            if (levelSystem != null)
            {
                levelSystem.GainExperienceFlatRate(30);
                Destroy(gameObject);
            }
        }

    }
}
