using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Enemy : MonoBehaviour
{
    int Damage { get; set; }
    int Health { get; set; }

    public virtual void Chase() { }
    public virtual void Attack(GameObject player) { }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            Attack(collision.gameObject);
        }
    }

}

public class Gerk : Enemy
{
    public override void Chase()
    {
        base.Chase();
    }
}
