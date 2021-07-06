using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyAttack : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask targetLayers;
    public float attackRange, attackCD;
    public float attackDamage, speed;
    float attackTime;
    bool isAttackCD = false;
    Collider2D[] enemiesHit;


    // Update is called once per frame
    void Update()
    {
        enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayers);
        if (enemiesHit.Length == 0) transform.position += new Vector3((1 * speed) * Time.deltaTime, 0, 0);
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
            if(enemy.tag == "Minion")
            {
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
            }
            if(enemy.tag == "Boss")
            {
                enemy.GetComponent<Boss>().TakeDamage(attackDamage);
            }
            if (enemy.tag == "Enemy Base")
            {
                enemy.GetComponent<EnemyBaseScript>().TakeDamage(attackDamage);
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
