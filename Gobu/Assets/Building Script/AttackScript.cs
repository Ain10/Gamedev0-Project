using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackScript : MonoBehaviour
{

    [SerializeField] float attackRange, AttackCD;
    [SerializeField] ContactFilter2D filter;
    [SerializeField] GameObject projectile;
    [SerializeField] Transform Firepoint;
    private float attackTime=0;
    public bool isAttackCD;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (attackTime <= Time.time)
        {
            isAttackCD = false;
        }
        RaycastHit2D enemyRange = Physics2D.Raycast(Firepoint.position, Firepoint.right,attackRange, filter.layerMask);
        if (enemyRange)
            {
                if (enemyRange.collider.gameObject.tag == "Minion" || enemyRange.collider.gameObject.tag == "Boss")
                {
                if (isAttackCD == false)
                {
                    
                    attackTime = Time.time + AttackCD;
                    
                    projAttack();
                }
  
            } 
        }
        

        //Vector2 targetPoint = enemyRange.collider.gameObject.transform.position;
        //Direction = targetPoint - (Vector2)transform.position;

    }

    private void projAttack()
    {
        Instantiate(projectile, Firepoint.position, Quaternion.identity);
        isAttackCD = true;
    }


}
