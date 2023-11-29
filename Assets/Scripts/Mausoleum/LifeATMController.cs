using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LifeATMController : MonoBehaviour
{
    public GameObject player;
    public GameObject shopCanvas;
    public GameObject messageCanvas;


    public void Start()
    {

    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            if (updater.treatCount >= 50)
            {
                shopCanvas.SetActive(true);
            }
            else
            {
                messageCanvas.SetActive(true);
            }
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            shopCanvas.SetActive(false);
            messageCanvas.SetActive(false);
        }
    }
}
