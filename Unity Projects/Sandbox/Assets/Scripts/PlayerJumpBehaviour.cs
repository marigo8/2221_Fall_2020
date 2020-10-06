using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJumpBehaviour : MonoBehaviour
{
    public float jumpStrength;
    public IntData jumpCount;
    
    private CharacterController controller;
    private Vector3 movement, forces;
    
    private void Start()
    {
        // Get Components
        controller = GetComponent<CharacterController>();
    }

    private void OnEnable()
    {
        jumpCount.SetValue(0);
    }

    private void Update()
    {
        // Gravity
        if (controller.velocity.y < 0)
        {
            forces.y = controller.velocity.y;
        }
        forces.y += Physics.gravity.y * Time.deltaTime;
        
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
        
        // Movement
        controller.Move((movement + forces) * Time.deltaTime);
    }
}
