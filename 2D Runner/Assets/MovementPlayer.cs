using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    private Rigidbody2D rb;
    private float moveInput;
    public float moveSpeed;
    public float jumpForce;

    private bool isGrounted;
    public Transform groundCheck;
    public float checkRadius;
    public LayerMask whatIsGround;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {
        isGrounted = Physics2D.OverlapCircle(groundCheck.position, checkRadius, whatIsGround);

        moveInput = Input.GetAxis("Horizontal");
        rb.velocity = new Vector2(moveInput * moveSpeed, rb.velocity.y);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && isGrounted == true)
        {
            rb.velocity = Vector2.up * jumpForce;
        }
    }
}
