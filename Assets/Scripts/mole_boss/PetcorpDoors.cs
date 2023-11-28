using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class PetcorpDoors : MonoBehaviour
{
    public Animator doorLeft;
    public Animator doorRight;

    // Start is called before the first frame update
    void Start()
    {
        doorLeft = GetComponent<Animator>();
        doorRight = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)         // detects collition -deb
    {
        if (collision.gameObject.CompareTag("Key"))
        {
            OpenDoors();
        }
    }

    public void OpenDoors()
    {
        doorRight.SetBool("Open", true);
        doorLeft.SetBool("Open", true);

        Invoke("NextScene", 2);
    }

    public void NextScene()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }
}
