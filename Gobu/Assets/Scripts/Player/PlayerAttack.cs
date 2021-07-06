using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class PlayerAttack : MonoBehaviour
{
    [SerializeField] Transform attackPoint;
    [SerializeField] float attackRange, attackCD, attackDamage, attackBufflast;
    [SerializeField] LayerMask enemyLayers;

    float attackTime,bufftime;
    bool isAttackCD = false;
    public bool attackBuffed = false;

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown(KeyCode.LeftShift) && !isAttackCD)
        {
            attackTime = Time.time + attackCD;
            Attack();
        }
        if (Time.time >= attackTime) isAttackCD = false;
        //return damage to normal with adjustment
        if (attackBuffed == true && Time.time >= bufftime)
        {

                
                attackBuffed = false;
                attackDamage = attackDamage / 2;
        }

    }
    public void BuffAttack()
    {
        attackBuffed = true;
        attackDamage = attackDamage * (float)2.25;
        bufftime = Time.time + attackBufflast;
    }
    void Attack(){

        //set Animation

        //Detect enemies
        Collider2D[] enemiesHit = Physics2D.OverlapCircleAll(attackPoint.position, attackRange, enemyLayers);

        //Damage enemies
        foreach(Collider2D enemy in enemiesHit)
        {
            if(enemy.tag == "Boss"){
                enemy.GetComponent<Boss>().TakeDamage(attackDamage);
            }else{
                enemy.GetComponent<Enemy>().TakeDamage(attackDamage);
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
