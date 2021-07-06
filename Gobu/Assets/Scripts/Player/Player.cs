using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{

    [SerializeField] float maxHealth, armor;
    public float currentHealth;

    // Start is called before the first frame update
    void Start()
    {
        currentHealth = maxHealth;
    }

    public void HealDamage(float healpoints)
    {
        currentHealth += healpoints;
        if (currentHealth >= maxHealth)
        {
            currentHealth = maxHealth;
        }
    }
    public void TakeDamage(float damage)
    {
        float defense = armor * 0.01f;
        currentHealth = currentHealth - (damage - Mathf.Floor(damage * defense));
        // if(this.armor < damage){
        //     this.currentHealth = this.currentHealth - (damage - this.armor);
        // }

        Debug.Log("Player HP: " + this.currentHealth);

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log(gameObject.name + " died!");

        Destroy(gameObject);

    }
}
