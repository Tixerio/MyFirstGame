using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMovement : MonoBehaviour
{
    private CharacterController controller;
    private Vector3 characterVelocity;
    private bool groundedCharacter;

    //character Speed values
    public float baseSpeed = 5.0f;
    public float speedMultiplier = 3.0f;
    private float characterSpeed;

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
        groundedCharacter = controller.isGrounded;

        //reset values for base state
        if (jumpCounter == 0)
        {  
            characterSpeed = baseSpeed;
            rotationSpeed = baseRotation;
        }

        //resets grounded values
        if (groundedCharacter && characterVelocity.y < 0)
        {
            jumpCounter = 0;
            characterVelocity.y = 0f;
        }

        // Get character input
        float horizontalInput = Input.GetAxis("Horizontal");
        float verticalInput = Input.GetAxis("Vertical");

        //makes character sprint
        if (Input.GetKey(KeyCode.LeftShift) && jumpCounter == 0)
        {

            characterSpeed += speedMultiplier;
            rotationSpeed = baseRotation / rotationMultiplier;
        }

        // Jump logic
        if (Input.GetKeyDown(KeyCode.Space) && jumpCounter < maxJumps)
        {
            characterVelocity.y = 0f;
            characterVelocity.y += Mathf.Sqrt(jumpHeight * -3.0f * gravityValue);
            jumpCounter += 1;
        }

        
        // Rotate character
        transform.Rotate(0f, horizontalInput * rotationSpeed * Time.deltaTime, 0f);

        // Move character forward
        Vector3 move = transform.forward * verticalInput;
        controller.Move(move * Time.deltaTime * characterSpeed);

        // Apply gravity and then move character in local space
        characterVelocity.y += gravityValue * Time.deltaTime;
        controller.Move(characterVelocity * Time.deltaTime);
    }


    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("point success");
        if (other.CompareTag("Point"))
        {
            Destroy(other.gameObject); // Destroy the player character
        }
    }

}
