using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] List<GameObject> enemyMinions;
    [SerializeField] GameObject Boss;
    [SerializeField] float secondsBetweenSpawn = 0.7f, secBeforeBoss;
     float nextSpawnTime = 5;
    public bool bossSpawned=false;

    // Update is called once per frame
    void Update()
    {

        if(Time.time >= nextSpawnTime){
            nextSpawnTime = Time.time + secondsBetweenSpawn;
            Instantiate(enemyMinions[Random.Range(0, enemyMinions.Count)],new Vector3(Random.Range(transform.position.x, transform.position.x+1),transform.position.y, 0),Quaternion.identity);
        }
        if(Time.time >= secBeforeBoss && bossSpawned == false)
        {
            Instantiate(Boss, transform.position, Quaternion.identity);
            bossSpawned = true;
        }
    }
}
