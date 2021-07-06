using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AllyRangeAttack : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask targetLayers;
    [SerializeField] GameObject ArrowProjectile;
    public float attackRange, attackCD;
    public float speed;
    float attackTime;
    bool isAttackCD = false;
    Collider2D[] enemiesHit;

    private void Update()
    {
        enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, targetLayers);
        if (enemiesHit.Length == 0) transform.position += new Vector3((1 * speed) * Time.deltaTime, 0, 0);
        else if (enemiesHit.Length > 0 && !isAttackCD)
        {
            attackTime = Time.time + attackCD;
            
            Attack();
        }
        if (Time.time >= attackTime) isAttackCD = false;
    }
    private void Attack()
    {
        Instantiate(ArrowProjectile, attackPoint.position, Quaternion.identity);
        isAttackCD = true;
    }

        void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
