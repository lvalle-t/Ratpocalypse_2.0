using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ant_test : MonoBehaviour
{
    //// Start is called before the first frame update
    public float _health = 3;
<<<<<<< Updated upstream
    public int Hitpoints;
    public spider_healthbar Healthbar;

=======
<<<<<<< HEAD
    private FlashDamage flashDamage;

    void Start()
    {
        flashDamage = GetComponent<FlashDamage>();
    }
=======
    public int Hitpoints;
    public spider_healthbar Healthbar;

>>>>>>> c9291b28d7a0d53127624018101a223e3eb10784
>>>>>>> Stashed changes
    public float Health
    {
       set
       {
           _health = value;

           if (_health <= 0)
           {
               Destroy(gameObject);
           }
       }
       get
       {
           return _health;
       }
    }
    void TakeDamage(float damage)
    {
       flashDamage.FlashOnDamage();
       Debug.Log("Ant Hit " + damage);
       Health -= damage;
    }
}
