using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TRISTANSpunchHitbox : MonoBehaviour
{
    // Start is called before the first frame update
    public Collider2D punchCollider;
    public float punchDamage;

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
        if (col.tag == "Alligator_Boss" || col.tag == "Enemy")
        {
            col.GetComponent<PolygonCollider2D>().SendMessage("TakeDamage", punchDamage);
        }

    }
}
