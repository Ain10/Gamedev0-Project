using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ally : MonoBehaviour
{
    public float maxHealth, armor;
    public float currentHealth;

    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {

        float defense = armor * 0.01f;
        currentHealth = currentHealth - (damage - Mathf.Floor(damage * defense));
        Debug.Log("HP: " + currentHealth);
        Debug.Log(transform.name + " has taken damage");

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    public void HealDamage(float healpoints)
    {
        currentHealth += healpoints;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    private void Die()
    {
        Debug.Log("Ally dies");

        Destroy(gameObject);
    }
}
