using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

//**********************************************************************************
// This Script Was Created Using the Following Resources:
//    - https://pll.harvard.edu/course/cs50s-introduction-game-development
//    - https://docs.unity3d.com/Manual/index.html
//    - Text MeshPro Unity Sample Scripts
//**************************************************************************deb*****

public class treat_text : MonoBehaviour
{
    private Text treatTxt;          // assignes the text and updates the count - deb

    // Start is called before the first frame update
    void Start()
    {
        treatTxt = GetComponent<Text>();        // gets access to text in treat component - deb
    }

    // Update is called once per frame
    void Update()
    {
        treatTxt.text = "Treats: " + updater.treatCount;    // assigning the text and counter updater before adding - deb
    }
}
