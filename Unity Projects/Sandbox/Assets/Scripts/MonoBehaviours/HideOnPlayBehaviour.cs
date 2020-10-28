using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
public class HideOnPlayBehaviour : MonoBehaviour
{
    private MeshRenderer meshRenderer;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        meshRenderer.enabled = false;
    }
}