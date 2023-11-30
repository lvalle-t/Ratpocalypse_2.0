using System.Collections;
using System.Collections.Generic;
using UnityEditor.Rendering.Universal;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ShopManagerScript : MonoBehaviour
{
    public treat_counter tc;
    public PlayerHealth ph;
    private float lifeAmount;


    public CatnipPotion[] potions;

    public GameObject shopUI;
    public Transform shopContent;
    public GameObject itemPrefab;

    public GameObject fullLifeMssg;

    // Start is called before the first frame update
    void Start()
    {
        foreach (CatnipPotion catnip in potions)
        {
            GameObject item = Instantiate(itemPrefab, shopContent);

            catnip.itemRef = item;

            foreach (Transform child in item.transform)
            {
                if (child.gameObject.name == "Quantity")
                {
                    child.gameObject.GetComponent<Text>().text = catnip.quantity.ToString();
                }
                else if (child.gameObject.name == "Cost")
                {
                    child.gameObject.GetComponent<Text>().text = "Price: " + catnip.cost;
                }
                else if (child.gameObject.name == "Name")
                {
                    child.gameObject.GetComponent<Text>().text = catnip.name;
                }
                else if (child.gameObject.name == "Image")
                {
                    child.gameObject.GetComponent<Image>().sprite = catnip.image;
                }
            }

            item.GetComponent<Button>().onClick.AddListener(() => { Purchase(catnip); });
        }
    }

    public void Purchase(CatnipPotion catnip)
    {
        if (updater.treatCount >= catnip.cost)
        {
            if (updater.playerHp < updater.maxHp)
            {
                updater.treatCount -= catnip.cost;

                lifeAmount = catnip.quantity;
                ph.LifePurchase(lifeAmount);
            }
            else
            {
                fullLifeMssg.SetActive(true);
                Invoke("FullLifeMssgOff", 2);
            }
        }
    }

    private void FullLifeMssgOff()
    {

        fullLifeMssg.SetActive(false);
    }
}

[System.Serializable]
public class CatnipPotion
{
    public string name;
    public int id;
    public int cost;
    public Sprite image;
    public float quantity;
    //[HideInInspector] public int quantity;
    [HideInInspector] public GameObject itemRef;
}