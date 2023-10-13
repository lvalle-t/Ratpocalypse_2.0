using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlligatorHpController : MonoBehaviour
{

	public int maxHealth = 1000;
	public int currentHealth;

	public AlligatorHpSlider healthBar;

	void Start()
	{
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.Space))
		{
			TakeDamage(20);
		}
	}

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		healthBar.SetHealth(currentHealth);
	}
}
