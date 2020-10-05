using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f, sprintModifier = 2f;

    private float rotateSpeed = 10f, speedModifier;
    private Rigidbody rb;
    
    private void Start()
    {
        // Get Components
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        // Input
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");
        var movement = new Vector3(hInput,0,vInput);

        // Sprint
        speedModifier = 1f;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedModifier *= sprintModifier;
        }
        
        // Move Player
        movement = Vector3.ClampMagnitude(movement, 1);
        rb.MovePosition(transform.position + movement * (moveSpeed * speedModifier * Time.fixedDeltaTime));

        // Rotate Player
        if (movement.magnitude > 0)
        {
            var rotation = Quaternion.LookRotation(movement.normalized);
            rotation = Quaternion.Lerp(transform.rotation, rotation, rotateSpeed * Time.fixedDeltaTime);
            rb.MoveRotation(rotation);
        }
    }
}