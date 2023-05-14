using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target; // The player's transform
    public float distanceFromTarget = 10f; // The distance from the player
    public float sensitivity = 150f; // Mouse sensitivity
    private float xRotation = 0f;
    private float yRotation = 0f;

    private void Start()
    {
        // Make the cursor invisible and locked at the center of the screen
        Cursor.lockState = CursorLockMode.Locked;
    }

    private void Update()
    {
        // Get mouse input
        float mouseX = Input.GetAxis("Mouse X") * sensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * sensitivity * Time.deltaTime;

        // Calculate the new rotation of the camera based on mouse movement
        xRotation -= mouseY;
        yRotation += mouseX;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f); // This line prevents the camera from flipping when looking up or down

        // Update the camera's position to be a fixed distance behind the player
        Vector3 newPosition = target.position - (Quaternion.Euler(xRotation, yRotation, 0f) * Vector3.forward * distanceFromTarget);
        transform.position = newPosition;

        // Make the camera look at the player
        transform.LookAt(target);
    }
}
