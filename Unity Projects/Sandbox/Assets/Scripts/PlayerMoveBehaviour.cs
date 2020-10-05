using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMoveBehaviour : MonoBehaviour
{
    public float moveSpeed = 5f, sprintModifier = 2f;
    private float rotateSpeed = 10f, speedModifier;

    private Vector3 forces = Vector3.zero;
    
    private CharacterController controller;
    
    private void Start()
    {
        // Get Components
        controller = GetComponent<CharacterController>();
    }

    private void Update()
    {
        // Input
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");
        var movement = new Vector3(hInput, 0, vInput);

        // Sprint
        speedModifier = 1f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedModifier *= sprintModifier;
        }
        
        // Gravity
        if (controller.velocity.y < 0)
        {
            forces.y = controller.velocity.y;
        }
        forces.y += Physics.gravity.y * Time.deltaTime;
        Debug.Log(controller.isGrounded);

        // Move Player
        movement = Vector3.ClampMagnitude(movement, 1);
        movement *= moveSpeed * speedModifier;
        
        controller.Move((movement + forces) * Time.deltaTime);

        // Rotate Player
        if (movement.magnitude > 0)
        {
            var rotation = Quaternion.LookRotation(movement.normalized);
            rotation = Quaternion.Lerp(transform.rotation, rotation, rotateSpeed * Time.deltaTime);
            transform.rotation = rotation;
        }
    }
}
