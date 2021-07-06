using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ImperialMage : MonoBehaviour
{

    [SerializeField] Transform attackPoint;
    [SerializeField] LayerMask targetLayers;
    [SerializeField] GameObject enemyArrowProjectile;



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
        }
        if(currentHealth < (maxHealth * 0.30) && !lowHealth){
            lowHealth = true;
            Debug.Log("attack up");
            transform.gameObject.GetComponent<Boss>().currentHealth += (maxHealth * .25f);
        }
    }

    public void Attack()
    {
        Debug.Log("atk from imperial mage");
        Instantiate(enemyArrowProjectile, new Vector3(attackPoint.position.x + 7f, attackPoint.position.y,0),Quaternion.identity);
    }
}
