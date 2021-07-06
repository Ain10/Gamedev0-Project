using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatoonCommander : MonoBehaviour
{
    [SerializeField] GameObject slash;
    float maxHealth, currentHealth;
    bool halfHealth, lowHealth;
    // Start is called before the first frame update
    void Start()
    {
        
        halfHealth = false;
        lowHealth = false;
        maxHealth = transform.gameObject.GetComponent<Boss>().maxHealth;
    }

    // Update is called once per frame
    void Update()
    {
        currentHealth = transform.gameObject.GetComponent<Boss>().currentHealth;
        if(currentHealth < (maxHealth / 2) && !halfHealth){
            Debug.Log("Slash Attack!");
            halfHealth = true;
            //launch slash attack
            GameObject slashAtk = Instantiate(slash,new Vector3(transform.position.x,transform.position.y, 0),Quaternion.identity);
            slashAtk.GetComponent<Rigidbody2D>().AddForce(transform.forward * 8000);
            
        }
        if(currentHealth < (maxHealth * 0.10) && !lowHealth){
            lowHealth = true;
            //heal
            Debug.Log("Heal");
            transform.gameObject.GetComponent<Boss>().currentHealth += (maxHealth * .75f);
        }
    }
}
