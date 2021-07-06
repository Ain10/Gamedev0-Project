using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileScript : MonoBehaviour
{
    [SerializeField] float speed = 20f;
    [SerializeField] float damage;
    public Rigidbody2D rb;
    private void Start()
    {
        rb.velocity = transform.right * speed;
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.tag == "Minion" )
        {
            Enemy enemy = collision.GetComponent<Enemy>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }

        }
        else if(collision.transform.tag == "Boss")
        {
            Boss enemy = collision.GetComponent<Boss>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
            
    }
}
