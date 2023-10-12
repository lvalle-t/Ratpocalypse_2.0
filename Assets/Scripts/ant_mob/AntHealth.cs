using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// using UnityEngine.SceneManagement;

public class AntHealth : MonoBehaviour
{

	public int maxHealth=3;
    private int currentHealth;

	// public GameObject deathEffect;

    void Start(){
        currentHealth = maxHealth;
    }

	void Update(){
        if(currentHealth <= 0){
            Debug.Log("I am Dead!");
            Destroy(gameObject);
            //die animation drop treat

        }
    }

    public void TakeDamage(int attackDamage){
        currentHealth -= attackDamage;
    }
}