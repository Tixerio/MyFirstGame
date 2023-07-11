using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    //player base variables
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;

    //character Speed values
    public float baseSpeed = 5.0f;
    public float speedMultiplier = 3.0f;
    private float playerSpeed;

    //rotation variables
    public float baseRotation = 190;
    private float rotationSpeed;
    public float rotationMultiplier = 1.3f;

    //jump variables
    public float jumpHeight = 1.5f;
    private int jumpCounter = 0;
    public int maxJumps = 2;

    //physic variables
    public float gravityMultiplier = 3.2f;
    private float gravityValue;


    private void Start()
    {
        //initiate gravity, need the multiplier, cant be used before because the compiler hasnt initiated it yet
        gravityValue = -9.81f * gravityMultiplier;
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
       
        //initiated grounded
        groundedPlayer = controller.isGrounded;

        //reset values for base state
        if (jumpCounter == 0)
        {
            playerSpeed = baseSpeed;
            rotationSpeed = baseRotation;
        }
       
        //resets grounded values
        if (groundedPlayer && playerVelocity.y < 0)
        {
            jumpCounter = 0;
            playerVelocity.y = 0f;
        }

        // Get player input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //makes character sprint
        if(Input.GetKey(KeyCode.LeftShift) && jumpCounter == 0)
        {
            playerSpeed += speedMultiplier;
            rotationSpeed = baseRotation / rotationMultiplier;
        }

        // Rotate character
        transform.Rotate(0f, horizontalInput * rotationSpeed * Time.deltaTime, 0f);

        // Move character forward
        Vector3 move = transform.forward * verticalInput;
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Jump logic
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter < maxJumps)
        {
            playerVelocity.y = 0f;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            jumpCounter += 1;
        }

        // Apply gravity and then move character in local space
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);
    }
}
