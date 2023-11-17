using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class score_text : MonoBehaviour
{
    private Text scoreTxt;          // assignes the text and updates the count - deb

    // Start is called before the first frame update
    void Start()
    {
        scoreTxt = GetComponent<Text>();        // gets access to text in treat component - deb
    }

    // Update is called once per frame
    void Update()
    {
        //scoreTxt.text = "Score: " + updater.scoreCount;    // assigning the text and counter updater before adding - deb
    }
}
