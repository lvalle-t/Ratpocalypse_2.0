using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake_boss_spawner : MonoBehaviour
{

    public GameObject snake;
    private int onEnter = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (onEnter == 0 && col.gameObject.tag == "Player")
        {
            Instantiate(snake, new Vector3(12, 16, 1), Quaternion.identity);
            onEnter = 1;
        }
    }
}
