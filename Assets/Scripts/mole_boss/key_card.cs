using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class key_card : MonoBehaviour
{


    private void OnTriggerEnter2D(Collider2D collision)         // detects collition -deb
    {
        if (collision.gameObject.CompareTag("FirstFloor"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            Destroy(gameObject);
        }
    }
}
