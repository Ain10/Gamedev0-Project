using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProductionBuildingScript : MonoBehaviour
{
    public int goldProduction, speed;
    public float armor, currentHealth;
    ScoreTrack gold;
    private float productionTime = 0;
    public bool isProductionCD = false;



    void Update()
    {
        if (isProductionCD == false)
        {

            productionTime = Time.time + speed;
            increaseGold();

        }
        if (productionTime <= Time.time)
        {
            isProductionCD = false;
        }
    }
    public void TakeDamage(float damage)
    {
        float defense = armor * 0.01f;
        currentHealth = currentHealth - (damage - Mathf.Floor(damage * defense));
 
       

        if (currentHealth <= 0)
        {
            Die();
        }
    }

    private void Die()
    {
        //LOSE CONDITION HERE
    }

    private void increaseGold()
    {
        gold = FindObjectOfType<ScoreTrack>();
        gold.setCurrency(gold.getCurrency() + goldProduction);
        isProductionCD = true;
    }
}
