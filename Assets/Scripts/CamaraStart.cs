using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraStartPosition : MonoBehaviour
{
    public Transform mainCharacter; // Reference to your main character's Transform
    private Vector3 initialCameraPosition;

    private void Awake()
    {
        initialCameraPosition = transform.position;
    }

    private void Start()
    {
        if (mainCharacter != null)
        {
            // Set the camera's position to match the main character's position.
            transform.position = mainCharacter.position + initialCameraPosition;
        }
        else
        {
            Debug.LogWarning("Main Character not assigned to CameraStartPosition script.");
        }
    }
}
