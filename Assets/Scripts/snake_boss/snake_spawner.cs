using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class snake_spawner : MonoBehaviour
{

    public GameObject boss;
    private int counter = 0;
    public SpriteRenderer fall_warning_box;
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
            Instantiate(boss, new Vector3(11, 5, 0), Quaternion.identity);
            fall_warning_box.enabled = true;
            counter = 1;

            float duration = 1.0f;

            Invoke("DisableSpriteRenderer", duration);
        }
    }

    private void DisableSpriteRenderer()
    {
        fall_warning_box.enabled = false;
    }
}