using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Events;

public class key : MonoBehaviour
{
    public enum InteractionType { NONE, Pickup, Examine, GrabDrop}
    public enum ItemType { Staic, Consumables}
    [Header("Attributes")]

    public InteractionType interaciton;
    public ItemType itemType;
    [Header("Exmaine")]

    public string description;
    [Header("Custom Events")]

    public UnityEvent customEvent;
    public UnityEvent consumeEvent;

    private void Reset()
    {
        //GetComponent<Collider2D>().isTrigger = true;
        //gameObject.layer = 1;
    }

    public void Interact()
    {
        //switch(interactType)
        //{
        //    case InteractionType.Pickup:
        //        FindObjectOfType<InventorySystem>().Pickup(gameObject);
        //        gameObject.SetActive(false); 
        //        break;
        //    case InteractionType.Examine:
        //        FindObjectOfType<InteractionSystem>().ExamineItem(this);
        //        gameObject.SetActive(false);
        //        break;
        //    case InteractionType.GrabDrop:
        //        FindObjectOfType<InteractionSystem>().ExamineItem(this);
        //        gameObject.SetActive(false);
        //        break;
        //    default:
        //        Debug.Log("Null Item");
        //        break;
        //}

        //customEvent.Invoke();
    }


    private void OnTriggerEnter2D(Collider2D collision)         // detects collition -deb
    {
        if (collision.gameObject.CompareTag("Player"))           // checks for assigned tag on object
        {
            Destroy(gameObject);                      // destroy key after counter updated 
        }
    }
}
