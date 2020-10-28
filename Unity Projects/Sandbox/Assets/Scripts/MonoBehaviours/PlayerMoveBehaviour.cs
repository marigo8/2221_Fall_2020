﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMoveBehaviour : MonoBehaviour
{
    // PUBLIC PROPERTIES //
    
    // Scriptable Objects
    public IntData jumpCount;
    public FloatData stamina;
    public CharacterStateData characterState;
    
    // Variables
    public float moveSpeed = 5f, sprintModifier = 2f, slowModifier = .5f, jumpStrength = 3.5f, tempClimbStrength;
    public bool godMode;
    
    // PRIVATE PROPERTIES //
    
    // Variables
    private bool staminaCoolingDown;
    private float rotateSpeed = 10f, speedModifier = 1f;
    private Vector3 movement, forces = Vector3.zero;
    
    // Components
    private CharacterController controller;
    private Coroutine sprintCoroutine;

    private void Start()
    {
        // Get Components
        controller = GetComponent<CharacterController>();
        
        // Reset ScriptableObjects
        stamina.SetValueToMax();
        jumpCount.SetValue(0);
    }

    private void Update()
    {
        // Reset Movement
        movement = Vector3.zero;
        
        // Gravity
        Gravity();
        
        // Character States
        switch (characterState.currentState)
        {
            case CharacterStateData.States.Walking:
                WalkRun();
                Jump();
                TempClimb();
                break;
            
            case CharacterStateData.States.Throwing:
                
                break;
            
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        // Apply Movement
        controller.Move((movement + forces) * Time.deltaTime);
    }

    private void Gravity()
    {
        // Gravity
        if (controller.isGrounded)
        {
            forces.y = 0;
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
        if (Input.GetButtonDown("Sprint") && !staminaCoolingDown)
        {
            if (sprintCoroutine != null) // if a coroutine is already running...
            {
                StopCoroutine(sprintCoroutine); // stop coroutine
            }
            sprintCoroutine = StartCoroutine(Sprint()); // start coroutine
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

    private IEnumerator Sprint()
    {
        // Sprinting Speed
        speedModifier = sprintModifier;
        
        // Deplete Stamina
        while (Input.GetButton("Sprint") && stamina.value > 0)
        {
            if (!godMode)
            {
                stamina.AddToValue(-Time.fixedDeltaTime);
            }

            yield return new WaitForFixedUpdate();
        }
        
        // Stop Sprinting
        if (stamina.value > 0)
        {
            // Regular Speed
            speedModifier = 1f;
            yield return new WaitForSeconds(1f);
        }
        else
        {
            // Slow Speed
            staminaCoolingDown = true;
            speedModifier = slowModifier;
            yield return new WaitForSeconds(2f);
        }
        
        // Regenerate Stamina
        while (!stamina.IsMaxed)
        {
            stamina.AddToValue(Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
        
        // End
        speedModifier = 1f;
        staminaCoolingDown = false;
    }

    private void Jump()
    {
        // On Grounded
        if (controller.isGrounded)
        {
            jumpCount.SetValue(0);
        }
        else if (jumpCount.value == 0)
        {
            jumpCount.SetValue(1);
        }
            
        // Jump
        if (Input.GetButtonDown("Jump") && !jumpCount.IsMaxed)
        {
            forces.y = jumpStrength;
            jumpCount.AddToValue(1);
        }
    }

    private void TempClimb()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            forces.y = tempClimbStrength;
        }
    }
}