using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bulletScript : MonoBehaviour
{
    // Start is called before the first frame update
    private Vector3 mousePos;
    private Camera mainCam;
    private Rigidbody2D rb;
    public float force;
    public Collider2D bulletCollider;
    public float bulletDamage = 0.2f;

    void Start()
    {
        mainCam = GameObject.FindGameObjectWithTag("MainCamera").GetComponent<Camera>();
        rb = GetComponent<Rigidbody2D>();
        mousePos = mainCam.ScreenToWorldPoint(Input.mousePosition);
        Vector3 direction = mousePos-transform.position;
        rb.velocity = new Vector2(direction.x, direction.y).normalized * force;

        if (bulletCollider == null)
        {
            Debug.LogWarning("bulletCollider not set");
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if(col.CompareTag("Enemy") || col.CompareTag("snake_boss") || col.CompareTag("Mole_Boss") || col.CompareTag("Alligator_Boss") || col.CompareTag("rat_king"))
        {
            Destroy(gameObject);
            //Debug.Log("OnTrigger is Working");
            col.SendMessage("TakeDamage", bulletDamage);
        }
        else if(col.CompareTag("walls")){
            Destroy(gameObject);
        }
    }
    // void OnCollisionEnter2D(Collision2D col)
    // {
    //     col.collider.SendMessage("TakeDamage", bulletDamage,SendMessageOptions.DontRequireReceiver);
    // }
    // Update is called once per frame
}
