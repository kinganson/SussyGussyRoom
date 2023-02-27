using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class player_movement : MonoBehaviour
{
   private CharacterController m_controller;
   public float m_speed = 0.7f;
    public float jumpForce = 10.0f; // force of player jump
    public float gravity = -9.81f; // force of gravity

    Vector3 velocity; // velocity of player movement
    public void Awake()
   {
       m_controller = GetComponent<CharacterController>();
   }
  
    public void Update()
    {
        // check if the player is grounded
        if (m_controller.isGrounded && velocity.y < 0)
        {
            velocity.y = -2.0f; // reset velocity to prevent character sinking into the ground
        }

        // get input for horizontal (left/right) and vertical (forward/backward) movement
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // calculate movement vector based on input and speed
        Vector3 move = transform.right * x + transform.forward * z;
        m_controller.Move(move * m_speed * Time.deltaTime); // move the player

        // check for jump input and apply force
        if (Input.GetButtonDown("Jump") && m_controller.isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpForce * -2.0f * gravity); // calculate jump force
        }

        // apply gravity to the player's velocity
        velocity.y += gravity * Time.deltaTime;
        m_controller.Move(velocity * Time.deltaTime); // move the player based on velocity
    }
}
