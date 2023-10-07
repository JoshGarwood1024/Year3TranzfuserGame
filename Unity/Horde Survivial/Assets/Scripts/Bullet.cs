using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float Damage;
    public GameObject scoreText;

    private float time = 0.0f;

     void OnTriggerEnter2D(Collider2D hitinfo)
    {
        EnemyChase enemyChase = hitinfo.GetComponent<EnemyChase>();
        if (enemyChase != null)
        {
            enemyChase.EnemyHealth -= Damage;
            Destroy(gameObject);

        }

   // void OnCollisionEnter2D(Collision collision)
       // {
          //  if (collision.gameObject.tag == "Enemy")
         //   {
               // GameObject scoretxt = Instantiate(scoreText, Camera.main.WorldToScreenPoint(collision.transform.position), Quaternion.identity, GameObject.Find("Canvas").transform);
               // scoretxt.transform.SetSiblingIndex(0);
               // ScoreScript.scoreValue += 1;

                //EnemyChase.EnemyHealth -= Damage;
                //Destroy(collision.gameObject);

                //Destroy(gameObject);
           //}

        //}
       
        
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
