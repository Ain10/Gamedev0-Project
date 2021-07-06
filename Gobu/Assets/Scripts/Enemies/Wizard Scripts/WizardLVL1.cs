using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardLVL1 : MonoBehaviour
{
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] Transform attackPoint;
    [SerializeField] public float fireDamage;
    bool done = false;
    public float hitbox;
    Collider2D[] enemiesHit;

    // Update is called once per frame
    void Update()
    {
        enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, hitbox, enemyLayers);
        Destroy(gameObject, 3f);
        if(enemiesHit.Length > 0 && done == false)
        {
            Attack(enemiesHit);
        }
    }

    private void Attack(Collider2D[] enemiesHit)
    {
        foreach (Collider2D enemy in enemiesHit)
        {
            if (enemy.name == "Player")
            {
                enemy.GetComponent<Player>().TakeDamage(fireDamage);
            }
            if (enemy.tag == "Ally Units")
            {
                enemy.GetComponent<Ally>().TakeDamage(fireDamage);
            }
            if (enemy.name == "Ally Base")
            {
                enemy.GetComponent<ProductionBuildingScript>().TakeDamage(fireDamage);
            }
        }
        done = true;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;
        Gizmos.DrawWireSphere(attackPoint.position, hitbox);
    }
}
