using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemDrop : MonoBehaviour
{
    // Start is called before the first frame update

    
    void Start()
    {

    }

    // private void OnTriggerEnter(Collider other){
    //     if(other.CompareTag("Player")){
    //         gameObject.SetActive(false);
    //     }
    // }

    // public void OnCollisionEnter2D(Collision2D collision)
    // {
    //     if (collision.gameObject.CompareTag("Player"))
    //     {
    //         // pickupTreat.Play();
    //          gameObject.SetActive(false);
    //     }
    // }
    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player"))
        {
            // pickupTreat.Play();
             gameObject.SetActive(false);
             updater.treatCount += 1;
        }
    }
    
}
