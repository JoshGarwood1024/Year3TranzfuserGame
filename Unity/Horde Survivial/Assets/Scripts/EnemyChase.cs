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

    private bool moving;


    // Start is called before the first frame update
    void Start()
    {
        EnemyHealth = startEnemyHealth;
        player = GameObject.Find("Player");
        speed = 8f;
        moving = true;

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

            Destroy(this.gameObject);
        }


        if(moving)
        {
            distance = Vector2.Distance(transform.position, player.transform.position);
            Vector2 direction = player.transform.position - transform.position;
            direction.Normalize();

            Vector2 moveTowardsPos = Vector2.MoveTowards(this.transform.position, new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z), speed * Time.deltaTime);
            rb.MovePosition(moveTowardsPos);
        }
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
        dmg += PlayerData.Instance.DamageBuff;

        //Vector3 pos = Camera.main.WorldToScreenPoint(transform.position);
        GameObject dmgTxt = Instantiate(damageTextPrefab, transform.position, Quaternion.identity, GameObject.Find("WorldSpaceCanvas").transform);
        dmgTxt.GetComponent<TextMeshProUGUI>().text = dmg.ToString();

        moving = false;

        EnemyHealth -= dmg;
        Vector3 dir = -(player.transform.position - transform.position);
        GetComponent<Rigidbody2D>().AddForce(dir * 1000, ForceMode2D.Impulse);

        StartCoroutine(Push());
    }

    IEnumerator Push()
    {
        yield return new WaitForSeconds(0.5f);
        moving = true;
    }
}
