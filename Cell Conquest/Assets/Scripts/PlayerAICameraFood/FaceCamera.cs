using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceCamera : MonoBehaviour
{
    private Camera playerCamera;

    private void Start()
    {
        // Get the Camera component from this game object or its children
        playerCamera = GetComponentInChildren<Camera>();
    }

    private void Update()
    {
        if (playerCamera != null)
        {
            transform.LookAt(transform.position + playerCamera.transform.rotation * Vector3.forward, playerCamera.transform.rotation * Vector3.up);
        }
    }
}
