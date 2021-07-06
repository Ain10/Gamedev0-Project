using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardLVL2SummonShitScript : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask enemyLayers;
    [SerializeField] GameObject summonUnit;
    public float attackRange, attackCD, speed;
    float attackTime;
    public bool isAttackCD = false;
    Collider2D[] enemiesHit;

    // Update is called once per frame
    void Update()
    {
        enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);
        if (enemiesHit.Length == 0) transform.position += new Vector3((-1 * speed) * Time.deltaTime, 0, 0);
        else if (enemiesHit.Length > 0 && !isAttackCD)
        {
            attackTime = Time.time + attackCD;
            Attack(enemiesHit);
        }
        if (Time.time >= attackTime) isAttackCD = false;
    }
    private void Attack(Collider2D[] enemiesHit)
    {

        Instantiate(summonUnit, transform.position, Quaternion.identity);
        Instantiate(summonUnit, new Vector2(transform.position.x + 1f, transform.position.y), Quaternion.identity);
        isAttackCD = true;
    }


    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
