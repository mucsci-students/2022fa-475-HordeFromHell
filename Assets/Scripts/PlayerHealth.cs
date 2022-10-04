using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerHealth : MonoBehaviour
{
    public int maxHealth = 100;
	public int currentHealth;
	public Canvas deathMenuUI;

	public HealthBar healthBar;

    // Start is called before the first frame update
    void Start()
    {
		currentHealth = maxHealth;
		healthBar.SetMaxHealth(maxHealth);
    }

	public void TakeDamage(int damage)
	{
		currentHealth -= damage;

		if(currentHealth <= 0)
		{
			currentHealth = 0;
			deathMenuUI.GetComponent<InGameMenus>().Die();
		}

		healthBar.SetHealth(currentHealth);
	}

	public void Heal(int health)
	{
		currentHealth += health;

		if(currentHealth > maxHealth)
		{
			currentHealth = maxHealth;
		}

		healthBar.SetHealth(currentHealth);
	}
}
