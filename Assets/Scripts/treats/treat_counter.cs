using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.UI;

//**********************************************************************************
// This Script Was Created Using the Following Resources:
//    - https://pll.harvard.edu/course/cs50s-introduction-game-development
//    - https://docs.unity3d.com/Manual/index.html
//    - Text MeshPro Unity Sample Scripts
//**************************************************************************deb*****

public class treat_counter : MonoBehaviour
{
    public int treatNum = 0;        // adds to the treatTxt count - deb

    public void TreatCollection()
    {
        treatNum = updater.treatCount += 1;                 // updates the treat counter
    }
}
