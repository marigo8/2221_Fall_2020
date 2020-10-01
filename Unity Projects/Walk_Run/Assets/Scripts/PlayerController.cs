using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
    public float moveSpeed = 5f, sprintModifier = 2f;
    private Rigidbody rb;
    
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    private void FixedUpdate()
    {
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");
        var movement = new Vector3(hInput,0,vInput);

        var speedModifier = 1f;

        if (Input.GetKey(KeyCode.LeftShift))
        {
            speedModifier *= sprintModifier;
        }
        
        movement = Vector3.ClampMagnitude(movement, 1);
        rb.MovePosition(transform.position + movement * (moveSpeed * speedModifier * Time.fixedDeltaTime));

        if (movement.magnitude > 0)
        {
            var rotation = Quaternion.LookRotation(movement.normalized);
            rb.MoveRotation(Quaternion.Lerp(transform.rotation, rotation, 10f * Time.deltaTime));
        }
    }
}
