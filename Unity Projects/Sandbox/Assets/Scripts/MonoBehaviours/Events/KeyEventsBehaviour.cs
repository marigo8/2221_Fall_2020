using UnityEngine;
using UnityEngine.Events;

public class KeyEventsBehaviour : MonoBehaviour
{
    public string key;

    public UnityEvent keyDownEvent, keyEvent, keyUpEvent;

    private void Update()
    {
        if (Input.GetKeyDown(key))
        {
            keyDownEvent.Invoke();
        }
        
        if (Input.GetKey(key))
        {
            keyEvent.Invoke();
        }
        
        if (Input.GetKeyUp(key))
        {
            keyUpEvent.Invoke();
        }
    }
}
