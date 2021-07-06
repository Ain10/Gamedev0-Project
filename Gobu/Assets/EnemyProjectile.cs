using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyProjectile : MonoBehaviour
{

    [SerializeField] float speed = 20f;
    [SerializeField] float damage;
    public Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
         rb.velocity = new Vector2(-1f * speed ,0);
        Destroy(gameObject, 5f);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.transform.tag == "Player")
        {
            Player enemy = collision.GetComponent<Player>();
            if (enemy != null)
            {
                
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }else if(collision.transform.tag == "Ally Units" )
        {
            Ally enemy = collision.GetComponent<Ally>();
            if(enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }

        }
        else if(collision.transform.tag == "Ally Base")
        {
            var enemy = collision.GetComponent<ProductionBuildingScript>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
                Destroy(gameObject);
            }
        }
            
    }
}
