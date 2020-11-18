using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.ExceptionServices;
using UnityEditor;
using UnityEngine;

public class PlayerFireBehaviour : MonoBehaviour
{
    public CharacterStateData characterState;
    public GameObject projectile;
    public Transform firePoint;
    public float startDelay, endDelay;

    public IntData ammoCount;

    private Camera cam;
    private Coroutine fireCoroutine;
    private WaitForSeconds startWait, endWait;

    private void Start()
    {
        cam = Camera.main;
        startWait = new WaitForSeconds(startDelay);
        endWait = new WaitForSeconds(endDelay);
    }

    private void Update()
    {
        if (!Input.GetButtonDown("Fire2")) return;
        if (ammoCount.value <= 0) return;
        if (characterState.currentState != CharacterStateData.States.Walking) return;

        if (fireCoroutine != null)
        {
            StopCoroutine(fireCoroutine);
        }

        fireCoroutine = StartCoroutine(Fire());
    }

    private IEnumerator Fire()
    {
        characterState.currentState = CharacterStateData.States.Throwing;
        yield return startWait;
        
        var ray = cam.ScreenPointToRay(Input.mousePosition);
        if (Physics.Raycast(ray, out var hit))
        {
            var target = hit.point;

            transform.LookAt(target);
            var rot = transform.eulerAngles;
            rot.x = 0;
            transform.rotation = Quaternion.Euler(rot);
        }
        Instantiate(projectile, firePoint.position, firePoint.rotation);
        ammoCount.AddToValue(-1);

        yield return endWait;

        characterState.currentState = CharacterStateData.States.Walking;
    }
}
