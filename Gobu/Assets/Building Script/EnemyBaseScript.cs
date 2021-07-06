using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBaseScript : MonoBehaviour
{
    public float armor, currentHealth;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] Transform perimterPoint;
    [SerializeField] float perimeter;
    [SerializeField] List<GameObject> spawnEnemy;
    Collider2D[] enemiesHit;
    [SerializeField] float secondsBetweenSpawn = 0.7f;
    float nextSpawnTime = 3;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        enemiesHit = Physics2D.OverlapCircleAll(perimterPoint.position, perimeter, enemyLayers);
        if(enemiesHit.Length == 1)
        {
            if (Time.time >= nextSpawnTime)
            {
                

                Instantiate(spawnEnemy[UnityEngine.Random.Range(0, spawnEnemy.Count)], perimterPoint.position,Quaternion.identity);
                nextSpawnTime = Time.time + secondsBetweenSpawn;
            }
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
        //WinCondition Here
    }
    void OnDrawGizmosSelected()
    {
        if (perimterPoint == null) return;

        Gizmos.DrawWireSphere(perimterPoint.position, perimeter);
    }
}
