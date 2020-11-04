using cakeslice;
using UnityEngine;

public class OutlineOccludedBehaviour : MonoBehaviour
{
    public Outline playerOutline;

    private void Start()
    {
        playerOutline.enabled = false;
    }

    private void Update()
    {
        if (Physics.Raycast(transform.position, transform.forward, out var hit,10f, LayerMask.GetMask("Default")))
        {
            Debug.Log(hit.collider.name);
            playerOutline.enabled = true;
        }
        else
        {
            playerOutline.enabled = false;
        }
    }
}
