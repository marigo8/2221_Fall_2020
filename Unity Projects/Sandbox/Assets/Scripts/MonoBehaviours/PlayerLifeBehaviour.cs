using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(MeshRenderer))]
[RequireComponent(typeof(CharacterController))]
[RequireComponent(typeof(PlayerMoveBehaviour))]
public class PlayerLifeBehaviour : MonoBehaviour
{
    public IntData health;
    public Transform spawnPoint;
    public int respawnTime;
    
    private MeshRenderer meshRenderer;
    private CharacterController controller;
    private PlayerMoveBehaviour playerMove;

    private WaitForSeconds respawnWait;

    private void Start()
    {
        meshRenderer = GetComponent<MeshRenderer>();
        controller = GetComponent<CharacterController>();
        playerMove = GetComponent<PlayerMoveBehaviour>();
        
        respawnWait = new WaitForSeconds(respawnTime);
        
        health.zeroEvent.AddListener(Die);
    }

    public void Die()
    {
        StartCoroutine(DeathCoroutine());
    }

    private IEnumerator DeathCoroutine()
    {
        meshRenderer.enabled = false;
        controller.enabled = false;
        playerMove.enabled = false;

        yield return respawnWait;
        
        transform.position = spawnPoint.position;
        var rotation = Vector3.zero;
        rotation.y = spawnPoint.eulerAngles.y;
        transform.eulerAngles = rotation;
        
        health.SetValueToMax();
        
        meshRenderer.enabled = true;
        controller.enabled = true;
        playerMove.enabled = true;
    }
}
