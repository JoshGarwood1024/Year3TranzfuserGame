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
    // Start is called before the first frame update
    void Start()
    {
        scaleX = transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {
        Vector2 playerInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical")).normalized;
        Vector2 moveForce = playerInput * moveSpeed;
        moveForce += forceToApply;
        forceToApply /= forceDamping;
        if(Mathf.Abs(forceToApply.x) <= 0.01f && Mathf.Abs(forceToApply.y) <= 0.01f)
        {
            forceToApply = Vector2.zero;
        }
        rb.velocity = moveForce;

        Vector3 characterScale = transform.localScale;
        if(Input.GetAxisRaw("Horizontal") < 0)
        {
            characterScale.x = -scaleX;
        }
        if (Input.GetAxisRaw("Horizontal") > 0)
        {
            characterScale.x = scaleX;
        }
        transform.localScale = characterScale;
    }
}
