using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform target;        // The main character's transform
    public Vector3 initialOffset;   // Initial offset from the character
    public float smoothSpeed = 0.125f; // Adjust this for camera smoothness

    private Vector3 offset;        // Current offset from the character

    private void Start()
    {
        if (target == null)
        {
            Debug.LogWarning("Camera target is not assigned. Assign the main character's Transform in the Inspector.");
            return;
        }

        // Calculate the initial offset
        offset = initialOffset;
        // Set the camera's position to the character's position plus the offset
        transform.position = target.position + offset;
    }

    private void LateUpdate()
    {
        if (target == null)
        {
            return;
        }

        // Calculate the desired position based on the character's position and offset
        Vector3 desiredPosition = target.position + offset;
        // Use Lerp for smooth camera movement
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, smoothSpeed);
        transform.position = smoothedPosition;
    }
}
