using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class punchHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D punchCollider;
    public float punchDamage = 2f;

    void Start()
    {
        if (punchCollider == null)
        {
            Debug.LogWarning("Punch Collider not set");
        }
    }

    /*void OnTriggerEnter2D(Collider2D collider)
    {
        collider.SendMessage("OnHit", punchDamage);
    }*/

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Alligator_Boss")
        {
            col.GetComponent<PolygonCollider2D>().SendMessage("TakeDamage", punchDamage);
        }

    }
}
