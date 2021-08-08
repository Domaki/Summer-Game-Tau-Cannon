using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public CharacterController controller;

    // Constants regarding player movement
    public float        speed              = 12f;
    public float        gravity            = -9.81f;
    public float        jumpHeight         = 3f;

    // Used in determining whether the player is on the ground
    private Transform    groundCheck;
    public float        groundDistance     = 0.4f;
    public LayerMask    groundMask;

    Vector3             move;
    Vector3             velocity;
    bool                isGrounded;

    public float        knockBackMultiplier = .5f;
    public float        knockBackTime = .25f;
    public float        knockBackCounter;
    public Vector3      knockBackMove;

    void Start()
    {
        groundCheck = GameObject.Find("GroundCheck").GetComponent<Transform>();
    }


    // Update is called once per frame
    void Update()
    {
        // Set to true if the groundCheck object collides with something in the groundMask
        isGrounded = Physics.CheckSphere(groundCheck.position, groundDistance, groundMask);

        // Keeps player from constantly accelerating while on the ground
        if (isGrounded && (velocity.y < 0))
        {
            velocity.y = -2f;
        }

        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        // Applies horizontal velocity to the player
        move = transform.right * x + transform.forward * z;

        // Math for the jump function
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            velocity.y = Mathf.Sqrt(jumpHeight * -2f * gravity);
        }

        controller.Move(move * speed * Time.deltaTime);

        // Applies acceleration towards the ground due to gravity
        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
        if (knockBackCounter > 0)
        {
            knockBackCounter -= Time.deltaTime;

            controller.Move(knockBackMove * knockBackMultiplier * knockBackCounter * Time.deltaTime);
        }
    }


    public void knockback(Vector3 direction, float pushForce)
    {
        knockBackCounter = knockBackTime;

        //direction = new Vector3(1f, 1f, 1f);
        knockBackMove = direction * pushForce;
    }
}
