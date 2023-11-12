
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class camera_shake : MonoBehaviour
{
    public CinemachineVirtualCamera CinemachineVirtualCamera;
    public GameObject player; // Reference to the player GameObject
    public float shakeIntensity = 1f;
    public float shakeTime = 0.2f;
    public float shakeDurationAfterCollision = 2f;

    private int counter = 0;

    private float timer;
    private CinemachineBasicMultiChannelPerlin _cbmcp;

    void Awake()
    {
        if (CinemachineVirtualCamera == null)
        {
            CinemachineVirtualCamera = GetComponent<CinemachineVirtualCamera>();
        }

        // Get the CinemachineBasicMultiChannelPerlin component
        _cbmcp = CinemachineVirtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
    }

    private void Start()
    {
        StopShake();
    }

    public void ShakeCamera()
    {
        // Apply the shake effect
        _cbmcp.m_AmplitudeGain = shakeIntensity;
        timer = shakeTime;
    }

    void StopShake()
    {
        // Stop the shake effect
        _cbmcp.m_AmplitudeGain = 0f;
        timer = 0;
    }

    void Update()
    {
        //For testing

        // if (Input.GetKey(KeyCode.Space))
        // {
        //     ShakeCamera();
        // }

        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            StopShake();
        }
        CinemachineVirtualCamera.Follow = player.transform;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Player") && counter == 0)
        {
            ShakeCamera();
            StartCoroutine(StopShakeAfterDuration(shakeDurationAfterCollision));
            counter = 1;
        }
    }

    private IEnumerator StopShakeAfterDuration(float duration)
    {
        yield return new WaitForSeconds(duration);
        StopShake();
    }

}
