using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    public GameObject scoreText;

    private float time = 0.0f;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.tag == "Enemy")
        {
            GameObject scoretxt = Instantiate(scoreText, Camera.main.WorldToScreenPoint(collision.transform.position), Quaternion.identity, GameObject.Find("Canvas").transform);
            scoretxt.transform.SetSiblingIndex(0);
            Destroy(collision.gameObject);

            Destroy(gameObject);
        }
        
    }


    private void Update()
    {
        if(time > 5)
        {
            Destroy(gameObject);
        }

        time += Time.deltaTime;
    }
}
