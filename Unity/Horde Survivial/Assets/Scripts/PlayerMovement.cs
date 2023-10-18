using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public Rigidbody2D rb;
    public float moveSpeed;
    public Vector2 forceToApply;
    public float forceDamping;

    private float scaleX;

    public Animator anim;

    // Start is called before the first frame update
    void Start()
    {
        scaleX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        //anim.SetFloat("Speed", Mathf.Abs(forceToApply));
        float horz = Input.GetAxisRaw("Horizontal");
        float vert = Input.GetAxisRaw("Vertical");

        Vector2 playerInput = new Vector2(horz, vert).normalized;
        Vector2 moveForce = playerInput * moveSpeed;
        moveForce += forceToApply;
        forceToApply /= forceDamping;
        
        if(Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
        {
            forceToApply = Vector2.zero;
        }
        rb.velocity = moveForce;

        Vector3 characterScale = transform.localScale;
        if(horz < 0)
        {
            characterScale.x = -scaleX;
        }
        if (horz > 0)
        {
            characterScale.x = scaleX;
        }
        transform.localScale = characterScale;

        GetComponent<Animator>().SetFloat("Speed", Mathf.Abs(horz) + Mathf.Abs(vert));

        if(Mathf.Abs(horz) + Mathf.Abs(vert) > 0)
        {
            GetComponent<Animator>().SetTrigger("Squish");
        }
    }
}
