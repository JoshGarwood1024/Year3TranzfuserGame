using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public Vector2 forceToApply;
    public float forceDamping;

    public ParticleSystem RunningParticle;

    public Animator anim;

    SpriteRenderer sr;

    // Start is called before the first frame update
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetFloat("Speed", Mathf.Abs(forceToApply));
        float horz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        Vector2 playerInput = new Vector2(horz, vert).normalized;
        if(PlayerData.Instance) moveSpeed *= PlayerData.Instance.SpeedBuffMultiplier;
        Vector2 moveForce = playerInput * moveSpeed;
        moveForce += forceToApply;
        forceToApply /= forceDamping;
        
        if(Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
        {
            forceToApply = Vector2.zero;
        }
        rb.velocity = moveForce;

        if(horz < 0)
        {
            sr.flipX = true;
        }
        if (horz > 0)
        {
            sr.flipX = false;
        }

        GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(horz) + Mathf.Abs(vert));

        if(Mathf.Abs(horz) + Mathf.Abs(vert) > 0)
        {
            if(RunningParticle) RunningParticle.Play();
            GetComponent<Animator>().SetTrigger("Squish");
        }
    }
}
