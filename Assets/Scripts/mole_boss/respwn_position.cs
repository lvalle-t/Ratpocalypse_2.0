using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class respwn_position : MonoBehaviour
{

    private Vector3 respawnPosition;

    // Start is called before the first frame update
    void Start()
    {
        respawnPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        respawnPosition = transform.position;
    }

    private void FixedUpdate()
    {
        respawnPosition = transform.position;
    }

    public void ResponPos()
    {
        transform.position = respawnPosition;
    }
}
