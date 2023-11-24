using Cinemachine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class boss_camera_shake : MonoBehaviour
{
    public CinemachineVirtualCamera CinemachineVirtualCamera;
    public GameObject player;                         // Reference to the boss GameObject
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
        timer -= Time.deltaTime;

        if (timer <= 0)
        {
            StopShake();
        }
        CinemachineVirtualCamera.Follow = player.transform;
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Mole_Boss") || col.gameObject.CompareTag("Alligator_Boss") || col.gameObject.CompareTag("snake boss") && counter == 0)
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
