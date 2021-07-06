using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WizardLVL1Script : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] GameObject skill;
    [SerializeField] LayerMask enemyLayers;
    public float attackRange, attackCD, speed;
    float attackTime;
    bool isAttackCD = false;
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
        Instantiate(skill, new Vector2(enemiesHit[0].transform.position.x, enemiesHit[0].transform.position.y - 1f), Quaternion.identity);

        isAttackCD = true;
    }
    void OnDrawGizmosSelected()
    {
        if (attackPoint == null) return;

        Gizmos.DrawWireSphere(attackPoint.position, attackRange);
    }
}
