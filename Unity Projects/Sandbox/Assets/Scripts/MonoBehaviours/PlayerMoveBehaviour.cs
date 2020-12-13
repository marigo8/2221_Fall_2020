using System;
using System.Collections;
using System.Runtime.InteropServices;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(CharacterController))]
public class PlayerMoveBehaviour : MonoBehaviour
{
    // PUBLIC PROPERTIES //
    
    // Scriptable Objects
    public IntData jumpCount;
    public FloatData stamina;
    public CharacterStateData characterState;
    
    // Variables
    public float moveSpeed = 5f, sprintModifier = 2f, jumpStrength = 3.5f, dashSpeed = 7.5f, tempClimbStrength, knockBackStrength, jumpDisableDelay;
    public Vector3 parentForce = Vector3.zero;
    
    // Events
    public UnityEvent stoppedEvent, walkingEvent;

    // PRIVATE PROPERTIES //
    
    // Variables
    private bool staminaCoolingDown, canJump;
    private float rotateSpeed = 10f, airTime;
    private Vector3 movement, gravityForce = Vector3.zero, knockbackForce = Vector3.zero;
    
    // Components
    private CharacterController controller;
    private Coroutine sprintCoroutine;
    
    public void AddForce(Vector3 addedForce)
    {
        addedForce.y = 0;
        knockbackForce += addedForce;
    }

    private void OnEnable()
    {
        knockbackForce = Vector3.zero;
        gravityForce = Vector3.zero;
        parentForce = Vector3.zero;
    }

    private void Start()
    {
        // Get Components
        controller = GetComponent<CharacterController>();
        
        // Reset ScriptableObjects
        stamina.SetValueToMax();
        jumpCount.SetValue(0);
    }

    private void FixedUpdate()
    {
        // Physics
        Gravity();
        ExternalForce();
    }

    private void Update()
    {
        // Reset Movement
        movement = Vector3.zero;

        // Character States
        switch (characterState.currentState)
        {
            case CharacterStateData.States.Walking:
                WalkRun();
                Jump();
                walkingEvent.Invoke();
                //TempClimb();
                break;
            
            case CharacterStateData.States.Throwing:
                
                break;
            
            case CharacterStateData.States.Stopped:
                stoppedEvent.Invoke();
                break;
            
            case CharacterStateData.States.KnockBack:

                break;
            
            case CharacterStateData.States.Dialogue:
                LookAt();
                break;
            default:
                throw new ArgumentOutOfRangeException();
        }
        
        // Apply Movement
        controller.Move((movement + gravityForce + knockbackForce + parentForce) * Time.deltaTime);
    }

    private void LookAt()
    {
        transform.LookAt(characterState.lookAtTarget);
        var rotation = transform.eulerAngles;
        rotation.x = 0f;
        rotation.z = 0f;
        transform.eulerAngles = rotation;
    }

    private void Gravity()
    {
        // Gravity
        if (controller.isGrounded)
        {
            gravityForce.y = 0;
        }
        gravityForce.y += Physics.gravity.y * Time.fixedDeltaTime;
    }

    private void ExternalForce()
    {
        knockbackForce = Vector3.Lerp(knockbackForce, Vector3.zero, 5 * Time.fixedDeltaTime);
        if (knockbackForce.magnitude <0.01f)
        {
            knockbackForce = Vector3.zero;
        }

        // if (knockbackForce.magnitude > 0)
        // {
        //     movement += knockbackForce;
        // }
    }

    private void WalkRun()
    {
        // Input
        var hInput = Input.GetAxis("Horizontal");
        var vInput = Input.GetAxis("Vertical");
        movement = new Vector3(hInput, 0, vInput);

        // Sprint
        var speedModifier = 1f;
        if (Input.GetButton("Sprint") && stamina.value > 0)
        {
            speedModifier = sprintModifier;
            stamina.AddToValue(-Time.deltaTime);
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
            airTime = 0;
            canJump = true;
            jumpCount.SetValue(0);
        }
        else
        {
            airTime += Time.deltaTime;
            if (airTime >= jumpDisableDelay)
            {
                canJump = false;
            }
        }
        
        if (canJump)
        {
        }
        else if (jumpCount.value == 0)
        {
            jumpCount.SetValue(1);
        }
            
        // Jump
        if (Input.GetButtonDown("Jump") && !jumpCount.IsMaxed)
        {
            Debug.Log(airTime);
            gravityForce.y = jumpStrength;
            jumpCount.AddToValue(1);
        }
    }

    private void TempClimb()
    {
        if (Input.GetKeyDown(KeyCode.C))
        {
            gravityForce.y = tempClimbStrength;
        }
    }
}