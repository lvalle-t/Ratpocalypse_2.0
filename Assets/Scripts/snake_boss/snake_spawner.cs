using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake_spawner : MonoBehaviour
{

    public GameObject boss;
    private int counter = 0;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (counter == 0)
        {
            Instantiate(boss, new Vector3(11, 15, 0), Quaternion.identity);
            counter = 1;
        }
    }
}
