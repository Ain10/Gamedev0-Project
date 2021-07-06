using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildingScript : MonoBehaviour
{
    public Transform enemy;
    void Start()
    {
        
    }
    
    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Minnions" || collision.gameObject.tag == "Boss")
        {
            enemy = collision.gameObject.transform;
        }
    }

    public Transform getEnemy()
    {
        return this.enemy;
    }
}
