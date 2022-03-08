using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    // References to character controller and camera transform
    public CharacterController myController;
    public Transform cam;

    // Jump and walk speed
    public float speed;
    public float jump;

    // Simulate gravity
    private Vector3 velocity;
    private bool isGrounded;
    private float gravity = -9.8f;

    void Start()
    {
        
    }

    
    void Update()
    {
        // Player Input
        float horizontal = Input.GetAxisRaw("Horizontal");
        float vertical = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(horizontal, 0f, vertical).normalized;

        // Change movement direction according to camera direction
        if (direction.magnitude >= float.Epsilon)
        {
            float playerAngle = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;

            Vector3 moveDirection = Quaternion.Euler(0f, playerAngle, 0f) * Vector3.forward;

            myController.Move(moveDirection.normalized * speed * Time.deltaTime);
        }

        // Press space to jump
        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jump * -0.2f * gravity);
            isGrounded = false;
        }

        // Keep track of gravity
        velocity.y += gravity * Time.deltaTime;
        myController.Move(velocity * Time.deltaTime);
    }

    // Check if player is grounded
    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log(isGrounded);
        if (hit.gameObject.name == "Terrain")
        {
            isGrounded = true;
        }
    }
}
