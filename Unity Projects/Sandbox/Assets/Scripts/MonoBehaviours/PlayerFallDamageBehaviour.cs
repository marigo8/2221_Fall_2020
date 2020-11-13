using UnityEngine;

[RequireComponent(typeof(CharacterController))]
public class PlayerFallDamageBehaviour : MonoBehaviour
{
    public IntData playerHealth;
    public float fallThreshold, damageModifier;

    private CharacterController controller;

    private void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    private void OnControllerColliderHit(ControllerColliderHit hit)
    {
        if ((controller.collisionFlags & CollisionFlags.Below) == 0) return;
        if (!(controller.velocity.y < fallThreshold)) return;
        
        var fallDamage = (controller.velocity.y - fallThreshold) * damageModifier;
        playerHealth.AddToValue((int) fallDamage);
    }
}
