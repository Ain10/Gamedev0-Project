using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllySpawnPoint : MonoBehaviour
{
    [SerializeField] List<GameObject> allyUnits;
    [SerializeField] float secondsBetweenSpawn;
    float nextSpawnTime = 5;


    // Update is called once per frame
    void Update()
    {
        if (Time.time >= nextSpawnTime)
        {
            nextSpawnTime = Time.time + secondsBetweenSpawn;
            Instantiate(allyUnits[Random.Range(0, allyUnits.Count)], new Vector3(Random.Range(transform.position.x, transform.position.x + 1), transform.position.y, 0), Quaternion.identity);
        }
    }
}
