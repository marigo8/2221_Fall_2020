using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMoveBehaviour : MonoBehaviour
{
    public IntData jumpCount;
    public float moveSpeed = 5f, sprintModifier = 2f, jumpStrength;
    private float rotateSpeed = 10f, speedModifier;

    private Vector3 forces = Vector3.zero;
    
    private CharacterController controller;
    private Vector3 movement;

    private void Start()
    {
        // Get Components
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        Gravity();
        WalkRun();
        Jump();
        
        // Movement
        controller.Move((movement + forces) * Time.deltaTime);
    }

    private void Gravity()
    {
        // Gravity
        if (controller.velocity.y < 0) // This fixes issue where player halts at the peak of the jump.
        {
            forces.y = controller.velocity.y;
        }
        forces.y += Physics.gravity.y * Time.deltaTime;
    }

    private void WalkRun()
    {
        // Input
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");
        movement = new Vector3(hInput, 0, vInput);

        // Sprint
        speedModifier = 1f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedModifier *= sprintModifier;
        }

        // Move Player
        movement = Vector3.ClampMagnitude(movement, 1);
        movement *= moveSpeed * speedModifier;

        // Rotate Player
        if (movement.magnitude > 0)
        {
            var rotation = Quaternion.LookRotation(movement.normalized);
            rotation = Quaternion.Lerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
            transform.rotation = rotation;
        }
    }

    private void Jump()
    {
        // On Grounded
        if (controller.isGrounded)
        {
            jumpCount.SetValue(0);
        }
            
        // Jump
        if (Input.GetButtonDown("Jump") && !jumpCount.IsMaxed)
        {
            forces.y = jumpStrength;
            jumpCount.AddToValue(1);
        }
    }
}