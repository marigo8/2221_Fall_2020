using UnityEngine;

[CreateAssetMenu]
public class WaitData : ScriptableObject
{
    public float waitTime;

    public static WaitForFixedUpdate FixedWait = new WaitForFixedUpdate();

    private WaitForSeconds wait;

    public void Initialize()
    {
        wait = new WaitForSeconds(waitTime);
    }

    public WaitForSeconds Wait()
    {
        if (wait == null)
        {
            Initialize();
        }

        return wait;
    }
}
