using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 playerVelocity;
    private bool groundedPlayer;
    public float speedMultiplier = 4.0f;
    public float playerSpeed = 4.0f;
    private float jumpHeight = 1.0f;
    public float rotationSpeed = 180;
    public float gravityValue = -9.81f;
    private int jumpCounter = 0;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        groundedPlayer = controller.isGrounded;

        if (groundedPlayer)
        {
            jumpCounter = 0;
        }

        if (groundedPlayer && playerVelocity.y < 0)
        {
            playerVelocity.y = 0f;
        }

        // Get player input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        // Rotate character
        transform.Rotate(0f, horizontalInput * rotationSpeed * Time.deltaTime, 0f);

        if(Input.GetKey(KeyCode.LeftShift) && jumpCounter == 0)
        {
            Debug.Log("test");
            playerSpeed += speedMultiplier;
        }

        // Move character forward
        Vector3 move = transform.forward * verticalInput;
        controller.Move(move * Time.deltaTime * playerSpeed);

        // Jump logic
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter < 3)
        {
            playerVelocity.y = 0f;
            playerVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            jumpCounter += 1;
        }

        // Apply gravity
        playerVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(playerVelocity * Time.deltaTime);

        if (jumpCounter == 0)
        {
            playerSpeed = speedMultiplier;
        }
    }
}
