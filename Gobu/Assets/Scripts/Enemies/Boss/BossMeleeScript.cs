using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossMeleeScript : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] float attackRange, jumpInterval;
    public float attackCD, attackDamage, speed;
    float attackTime;
    bool isAttackCD = false;
    Collider2D[] enemiesHit;

    Transform target;
    void Start()
    {
        target = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
    }

    void Update()
    {
        enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        if (target != null)
        {
            if (enemiesHit.Length == 0)
            {
                if (transform.position.x < target.position.x)
                {
                    transform.localScale = new Vector3(-4f, 4f, 1f);
                }
                else
                {
                    transform.localScale = new Vector3(4f, 4f, 1f);
                }
                transform.position = Vector2.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            }
            else if (enemiesHit.Length > 0 && !isAttackCD)
            {
                attackTime = Time.time + attackCD;
                Attack(enemiesHit);
            }
        }

        if (Time.time >= attackTime) isAttackCD = false;
    }

    private void Attack(Collider2D[] enemiesHit)
    {
        foreach (Collider2D enemy in enemiesHit)
        {
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
