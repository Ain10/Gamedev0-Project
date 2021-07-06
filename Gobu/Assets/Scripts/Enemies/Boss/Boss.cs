using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
    public float maxHealth, maxMana, armor, currentHealth, currentMana;
    

    // Start is called before the first frame update
    void Start()
    {
        
        currentHealth = maxHealth;
        currentMana = maxMana;
    }

    // Update is called once per frame
    void Update()
    {
        // if(currentHealth <= (maxHealth / 2) && !halfHealth){
        //     Debug.Log("Rage!");
        //     halfHealth = true;
        //     armor += 10;
        //     transform.gameObject.GetComponent<BossAttack>().attackDamage += 20f;
        //     transform.gameObject.GetComponent<BossAttack>().attackCD -= 1.2f;
        //     transform.gameObject.GetComponent<BossAttack>().speed *= 2f;
        //     skill();
        // }
    }

    public void skill(){
        currentMana -= (maxMana / 2);

        //unleashes some kind of skill
        
    }

    public void TakeDamage(float damage)
    { 
        float defense = armor * 0.01f;
        currentHealth = currentHealth - (damage - Mathf.Floor(damage * defense));
        Debug.Log("Boss HP: " + currentHealth);

        if(currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        Debug.Log("Boss dies");

        Destroy(gameObject);
    }
}
