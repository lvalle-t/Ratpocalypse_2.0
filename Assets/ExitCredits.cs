using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ExitCredits : MonoBehaviour
{
    private void FixedUpdate()
    {
        GoBack();
    }

    public void GoBack()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene(0);
        }
    }
}
