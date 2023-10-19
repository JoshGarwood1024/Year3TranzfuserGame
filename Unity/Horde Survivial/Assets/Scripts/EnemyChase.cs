using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class EnemyChase : MonoBehaviour
{
    public GameObject player;
    public float speed;
    public float Damage;
    private float distance;

    public float EnemyHealth;
    public float startEnemyHealth;

    public GameObject XP;
    public Transform XpSpawnPoint;
    public GameObject Blood;

    public GameObject damageTextPrefab;

    private Rigidbody2D rb;

    //public GameObject scoreText;


    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth = startEnemyHealth;
        player = GameObject.Find("Player");
        speed = 8f;

        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (EnemyHealth <= 0)
        {
            GameObject xpgo = Instantiate(XP, XpSpawnPoint.position, XpSpawnPoint.rotation);
            xpgo.GetComponent<Rigidbody2D>().AddRelativeForce(Random.insideUnitCircle * 400);
            GameObject blood = Instantiate(Blood, XpSpawnPoint.position, XpSpawnPoint.rotation);
            ScoreScript.scoreValue += 1;

            player.GetComponent<PlayerAttacking>().EnemyDied(gameObject);
            player.GetComponent<Projectile>().EnemyDied(gameObject);

            Destroy(this.gameObject);
        }


        distance = Vector2.Distance(transform.position, player.transform.position);
        Vector2 direction = player.transform.position - transform.position;
        direction.Normalize();

        Vector2 moveTowardsPos = Vector2.MoveTowards(this.transform.position, player.transform.position, speed * Time.deltaTime);
        rb.MovePosition(moveTowardsPos);
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<CameraShake>().shakeDuration = 0.3f;
            PlayerHealth.PHealth -= Damage;
        }
    }

    public void Hurt(float dmg)
    {
/*        Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        GameObject dmgTxt = Instantiate(damageTextPrefab, pos, Quaternion.identity, GameObject.Find("Canvas").transform);
        dmgTxt.GetComponent<TextMeshProUGUI>().text = dmg.ToString();*/

        EnemyHealth -= dmg;
        Vector3 dir = -(player.transform.position - transform.position);
        GetComponent<Rigidbody2D>().AddForce(dir * 100, ForceMode2D.Impulse);

        
    }

}
