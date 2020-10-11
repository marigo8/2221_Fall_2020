using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerMoveBehaviour : MonoBehaviour
{
    public IntData jumpCount;
    public FloatData stamina;
    public float moveSpeed = 5f, sprintModifier = 2f, slowModifier = -.5f, jumpStrength;

    private bool staminaCoolingDown = false;
    private float rotateSpeed = 10f, speedModifier = 1f;
    private Vector3 movement, forces = Vector3.zero;
    private CharacterController controller;
    private Coroutine sprintCoroutine;

    private void Start()
    {
        // Get Components
        controller = GetComponent<CharacterController>();
        stamina.SetValueToMax();
        jumpCount.SetValue(0);
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
        if (Input.GetKeyDown(KeyCode.LeftShift) && !staminaCoolingDown)
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
        while (Input.GetKey(KeyCode.LeftShift) && stamina.value > 0)
        {
            stamina.AddToValue(-Time.fixedDeltaTime);
            yield return new WaitForFixedUpdate();
        }
        
        // Stop Sprinting
        if (stamina.value > 0)
        {
            // Regular Speed
            speedModifier = 1f;
            yield return new WaitForSeconds(.5f);
        }
        else
        {
            // Slow Speed
            staminaCoolingDown = true;
            speedModifier = slowModifier;
            yield return new WaitForSeconds(1);
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
            
        // Jump
        if (Input.GetButtonDown("Jump") && !jumpCount.IsMaxed && !staminaCoolingDown)
        {
            forces.y = jumpStrength;
            jumpCount.AddToValue(1);
        }
    }
}