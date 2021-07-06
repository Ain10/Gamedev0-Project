using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public float maxHealth, armor;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void TakeDamage(float damage)
    {
        // if(armor < damage){
        //     currentHealth = currentHealth - (damage - armor);
        // }

        float defense = armor * 0.01f;      
        currentHealth = currentHealth - (damage - Mathf.Floor(damage * defense));
        Debug.Log("HP: " + currentHealth);
        Debug.Log(transform.name + " has taken damage");

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Enemy dies");

        Destroy(gameObject);
    }

    
}
