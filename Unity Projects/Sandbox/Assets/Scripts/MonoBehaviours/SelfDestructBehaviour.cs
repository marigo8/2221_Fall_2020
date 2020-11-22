using UnityEngine;

public class SelfDestructBehaviour : MonoBehaviour
{
    // For some reason, whenever I have an object destroy itself through a Unity Event, it crashes the Unity Editor. This is a workaround.
    
    private bool destroyOnNextFrame;
    
    public void DestroyOnNextFrame()
    {
        destroyOnNextFrame = true;
    }

    private void Update()
    {
        if (destroyOnNextFrame) Destroy(gameObject);
    }
}
