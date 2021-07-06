using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImperialMage : MonoBehaviour
{
    [SerializeField] GameObject witch1, witch2;
    float maxHealth, currentHealth;
    bool halfHealth, lowHealth, highHealth;
    // Start is called before the first frame update
    void Start()
    {
        halfHealth = false;
        lowHealth = false;
        highHealth = false;
        maxHealth = transform.gameObject.GetComponent<Boss>().maxHealth;
        witch1.GetComponent<Enemy>().maxHealth = 65f;
        witch2.GetComponent<Enemy>().maxHealth = 85f;
        witch1.GetComponent<Enemy>().armor = 8f;
        witch2.GetComponent<Enemy>().armor = 12f;
        witch1.GetComponent<EnemyAttack>().attackCD = 2.2f;
        witch2.GetComponent<EnemyAttack>().attackCD = 2.75f;
        witch1.GetComponent<EnemyAttack>().attackDamage = 24f;
        witch2.GetComponent<EnemyAttack>().attackDamage = 30f;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = transform.gameObject.GetComponent<Boss>().currentHealth;
        if(currentHealth < (maxHealth * 0.75) && !highHealth){
            highHealth = true;
            Debug.Log("health up");
            witch1.GetComponent<Enemy>().currentHealth += 20f;
            witch2.GetComponent<Enemy>().currentHealth += 30f;
            witch1.GetComponent<Enemy>().maxHealth = 85f;
            witch2.GetComponent<Enemy>().maxHealth = 100;
        }
        if(currentHealth < (maxHealth / 2) && !halfHealth){
            halfHealth = true;
            Debug.Log("armor up");
            witch1.GetComponent<Enemy>().armor = 15f;
            witch2.GetComponent<Enemy>().armor = 20f;
            witch1.GetComponent<EnemyAttack>().attackCD = 1.8f;
            witch2.GetComponent<EnemyAttack>().attackCD = 2.2f;
        }
        if(currentHealth < (maxHealth * 0.30) && !lowHealth){
            lowHealth = true;
            Debug.Log("attack up");
            witch1.GetComponent<EnemyAttack>().attackDamage = 35f;
            witch2.GetComponent<EnemyAttack>().attackDamage = 45f;
            transform.gameObject.GetComponent<Boss>().currentHealth += (maxHealth * .25f);
        }
    }
}
