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

    public static int treatCount = 150;
    public static float playerHp = 9f;
    public static float alligatorHp = 60.0f;
    public static float antHp = 1.0f;
    public static float batHp = 1.0f;
    public static float moleHp = 40.0f;
    public static float ratHp = 1.0f;
    public static float snakeHp = 1.0f;

    public static float maxHp = 9f;

    //xp bar
    public static int currExp = 0;
    public static int maxExp = 500;
    public static int currLevel = 1;
    //player cat movement
    public static float speed = 6f;
}
