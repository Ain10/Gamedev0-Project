using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask enemyLayers;
    public float attackRange, attackCD;
    public float attackDamage, speed;
    float attackTime;
    bool isAttackCD = false;
    Collider2D[] enemiesHit;



    // Update is called once per frame
    void Update()
    {
        enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        if (enemiesHit.Length == 0)  transform.position += new Vector3((-1 * speed) * Time.deltaTime, 0,0);
        else if (enemiesHit.Length > 0 && !isAttackCD)
        {
            attackTime = Time.time + attackCD;
            Attack(enemiesHit);
        }
        if (Time.time >= attackTime) isAttackCD = false;
    }

    private void Attack(Collider2D[] enemiesHit)
    {
        foreach (Collider2D enemy in enemiesHit)
        {
            Debug.Log("Hit " + enemy.name);
            if (enemy.name == "Player")
            {
                enemy.GetComponent<Player>().TakeDamage(attackDamage);
            }
            if (enemy.tag == "Ally Units")
            {
                enemy.GetComponent<Ally>().TakeDamage(attackDamage);
            }
            if (enemy.name == "Ally Base")
            {
                enemy.GetComponent<ProductionBuildingScript>().TakeDamage(attackDamage);
            }
        }

        isAttackCD = true;
    }

    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
