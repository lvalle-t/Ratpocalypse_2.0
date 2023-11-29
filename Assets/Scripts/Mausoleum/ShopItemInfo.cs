using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopItemInfo : MonoBehaviour
{
    public int ID;
    public Text price;
    public Text quantity;
    public GameObject sm;

    // Update is called once per frame
    void Update()
    {
        price.text = "Price: " + sm.GetComponent<ShopManagerScript>().shopItems[1, ID].ToString();
        quantity.text = "Life: " + sm.GetComponent<ShopManagerScript>().lifeQuantity[1, ID].ToString();

    }
}
