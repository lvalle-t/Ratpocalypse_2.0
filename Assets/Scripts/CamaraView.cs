using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//**********************************************************************************
// This Script Was Created Using the Following Resources:
//    - https://pll.harvard.edu/course/cs50s-introduction-game-development
//    - https://docs.unity3d.com/Manual/index.html
//    - Text MeshPro Unity Sample Scripts
//**************************************************************************deb*****

public class CameraView : MonoBehaviour
{
    public GameObject player;
    public float smoothMotion;                         // smooths the player's motion so it is not choppy
    //public float offset;                             // stores the amount the camera should look ahead
    public Vector3 offset;                             // stores the amount the camera should look ahead

    private Vector3 position;                          // stores the player's position

    // Start is called before the first frame update
    void Start()
    {
        offset = new Vector3(0, 0, -1);
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(player.transform.position.x, player.transform.position.y, transform.position.z);
    }

    private void FixedUpdate()
    {
        if (player.transform.localScale.x > 0f)
        {
            position = new Vector3(position.x + offset.x, position.y + offset.y, position.z + offset.z);
        }
        else
        {
            position = new Vector3(position.x + offset.x, position.y + offset.y, position.z + offset.z);
        }

        transform.position = Vector3.Lerp(transform.position, position, smoothMotion * Time.deltaTime);
    }
}