using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class key : MonoBehaviour
{
    public Gate openGate;

    private void OnTriggerEnter2D(Collider2D collision)         // detects collition -deb
    {
        if (collision.gameObject.CompareTag("Gate"))
        {
            openGate.OpenGate();
        }
    }
}
