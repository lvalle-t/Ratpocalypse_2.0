using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//**********************************************************************************
// This Script Was Created Using the Following Resources:
//    - https://pll.harvard.edu/course/cs50s-introduction-game-development
//    - https://docs.unity3d.com/Manual/index.html
//    - Text MeshPro Unity Sample Scripts
//**************************************************************************deb*****

public class updater : MonoBehaviour
{
    // accumulates the treats, score, and adjusts
    // the hp as a collective of all scenes 

    public static int treatCount = 0;
    //public static int scoreCount = 0;
    public static float playerHp = 9f;
    public static float alligatorHp = 20.0f;
    public static float antHp = 1.0f;
    public static float batHp = 1.0f;
    public static float moleHp = 20.0f;
    public static float ratHp = 1.0f;
    public static float snakeHp = 1.0f;

    public static float maxHp = 9f;
}
