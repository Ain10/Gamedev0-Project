using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BanditCaptain : MonoBehaviour
{
    float maxHealth, currentHealth;
    bool halfHealth;
    // Start is called before the first frame update
    void Start()
    {
        halfHealth = false;
        maxHealth = transform.gameObject.GetComponent<Boss>().maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = transform.gameObject.GetComponent<Boss>().currentHealth;
        if(currentHealth < (maxHealth / 2) && !halfHealth){
            Debug.Log("Rage!");
            halfHealth = true;
            transform.gameObject.GetComponent<Boss>().armor += 10;
            transform.gameObject.GetComponent<BossMeleeScript>().attackDamage += 20f;
            transform.gameObject.GetComponent<BossMeleeScript>().attackCD -= 1.2f;
            transform.gameObject.GetComponent<BossMeleeScript>().speed *= 2f;
        }
    }
}
