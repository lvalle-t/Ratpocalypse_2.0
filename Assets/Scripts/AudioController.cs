using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioController : MonoBehaviour
{
    private static AudioController instance;

    // Add a public static property to access the instance.
    public static AudioController Instance
    {
        get { return instance; }
    }

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject); // Prevents the object from being destroyed during scene changes.
        }
        else
        {
            Destroy(gameObject); // Destroy duplicate AudioControllers.
        }
    }

    public void PlayMusic(AudioClip musicClip)
    {
        AudioSource audioSource = GetComponent<AudioSource>();

        if (audioSource != null)
        {
            audioSource.clip = musicClip;
            audioSource.loop = true;
            audioSource.Play();
        }
        else
        {
            Debug.LogError("Audio Source component not found on this GameObject.");
        }
    }
}
