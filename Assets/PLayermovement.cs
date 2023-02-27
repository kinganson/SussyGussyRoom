using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PLayermovement : MonoBehaviour
{
    public float playerSpeed;

    public float JumpForce;
    private bool IsGrounded = false;
    public GameObject GroundCheck;
    public float radius;
    public LayerMask WhatIsGround;

    public Rigidbody rb;


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        Jump();
    }
    public void Movement()
    {
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");

        // move player horizontally
        Vector3 movement = new Vector3(horizontal, 0f, vertical);
        transform.position += movement * playerSpeed * Time.deltaTime;
    }
    public void Jump()
    {
        IsGrounded = Physics.CheckSphere(GroundCheck.transform.position, radius, WhatIsGround);

        if (Input.GetKeyDown(KeyCode.Space) && IsGrounded)
        {
            rb.AddForce(Vector3.up * JumpForce, ForceMode.Impulse);
        }
    }
}
