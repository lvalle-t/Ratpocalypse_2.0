using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCredits : MonoBehaviour
{
    public AudioSource creditsMusic;

    
    void Update()
    {
        GoBack();
    }

    private void FixedUpdate()
    {
        GetComponents<AudioSource>()[0].Play();
    }

    public void GoBack()
    {
        if (Input.GetKeyDown(KeyCode.F5))
        {
            SceneManager.LoadScene(0);
        }
    }
}
