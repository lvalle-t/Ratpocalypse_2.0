using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Gate : MonoBehaviour
{
    public Animator gateAnima;

    // Start is called before the first frame update
    void Start()
    {
        gateAnima = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)         // detects collition -deb
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            OpenGate();
        }
    }

    public void OpenGate()
    {
        gateAnima.SetBool("isOpen", true);
        //gateAnima.SetTrigger("isOpening");

        Invoke("NextScene", 2);
    }

    private void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 2);
    }

    //private void CloseGate()
    //{
    //    gateAnima.SetBool("isClosing", true);
    //    GateIdle();
    //}

    //private void GateIdle()
    //{
    //    gateAnima.SetBool("isClosing", false);
    //    gateAnima.SetBool("isClosed", true);
    //}
}
