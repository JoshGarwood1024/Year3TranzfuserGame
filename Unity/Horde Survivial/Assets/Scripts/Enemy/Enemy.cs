using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public abstract class Enemy : MonoBehaviour
{
    [HideInInspector]
    public GameObject player;

    public GameObject XP;
    public GameObject Blood;

    public GameObject damageTextPrefab;

    public List<Sprite> BodyPartSprites;
    public GameObject BodyPartPrefab;

    public float Damage;
    public float Health;

    public float AmountSpawnPerWave;

    public GameObject[] lootItems;

    public virtual void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");

        if (lootItems.Length == 0)
        {
            //Debug.LogError("No loot items defined!");
            return;
        }


    }

    public virtual void Attack(GameObject p) {
        PlayerHealth.PHealth -= Damage;
        p.GetComponent<CameraShake>().shakeDuration = 0.2f;
    }

    public virtual void Hurt(float dmg)
    {
        dmg += PlayerData.Instance.DamageBuff;

        GameObject dmgTxt = Instantiate(damageTextPrefab, transform.position, Quaternion.identity, GameObject.Find("WorldSpaceCanvas").transform);
        dmgTxt.GetComponent<TextMeshProUGUI>().text = dmg.ToString();

        Health -= dmg;
    }

    public virtual void Death()
    {

        GameObject xpgo = Instantiate(XP, transform.position, transform.rotation);
        xpgo.GetComponent<Rigidbody2D>().AddRelativeForce(Random.insideUnitCircle * 400);

        foreach (Sprite bp in BodyPartSprites)
        {
            GameObject bodyPart = Instantiate(BodyPartPrefab, transform.position, transform.rotation);
            bodyPart.GetComponent<SpriteRenderer>().sprite = bp;
            bodyPart.GetComponent<Rigidbody2D>().AddRelativeForce(Random.insideUnitCircle * 200);
        }

        int randomIndex = Random.Range(0, lootItems.Length);
        GameObject selectedLoot = Instantiate(lootItems[randomIndex], transform.position, Quaternion.identity);


        Instantiate(Blood, transform.position, transform.rotation);
        ScoreScript.scoreValue += 1;

        Destroy(this.gameObject);
    }

    protected virtual void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Attack(collision.gameObject);
        }
    }

    protected virtual void Update()
    {
        if(Health <= 0)
        {
            Death();
        }
    }

}
