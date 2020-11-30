using UnityEngine;

public class QuitBehaviour : MonoBehaviour
{
    public float keyHoldTime = 5f;

    private float timer;
    private void Update()
    {
        if (Input.GetKey(KeyCode.Escape))
        {
            timer -= Time.deltaTime;
            if (timer <= 0f)
            {
                Application.Quit();
            }
        }
        else
        {
            timer = keyHoldTime;
        }
    }
}
