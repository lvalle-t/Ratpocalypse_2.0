using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpdateLevel : MonoBehaviour
{
    // Start is called before the first frame update
    private Text levelTxt;
    [SerializeField] LevelProgression lp;          // assignes the text and updates the count - deb

    // Start is called before the first frame update
    void Start()
    {
        levelTxt = GetComponent<Text>();        // gets access to text in treat component - deb
    }

    // Update is called once per frame
    void Update()
    {
        levelTxt.text = "XP Level: "+lp.CurrLevel.ToString();    // assigning the text and counter updater before adding - deb
    }
}
