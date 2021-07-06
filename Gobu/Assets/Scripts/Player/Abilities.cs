using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Abilities : MonoBehaviour
{

    public List<Image> skillImage;
    public List<Button> skill;
    private Button attack, heal;
    public float attackCD, healCD, HealValue;
    bool attackIsCD=false, healIsCD=false;
    private GameObject[] healUnits;

    void Start()
    {
        attack = skill[0].GetComponent<Button>();
        attack.onClick.AddListener(attackClick);
        heal = skill[1].GetComponent<Button>();
        heal.onClick.AddListener(healClick);
    }



    void Update()
    {

            healUnits = GameObject.FindGameObjectsWithTag("Ally Units");
        attackCheckCD();
        healcheckCD();
    }
    private void attackCheckCD()
    {
        //Attack Cooldown
        if (attackIsCD == false)
        {
            attack.image.fillAmount = 1;
            
        }
        else
        {
            attack.image.fillAmount -= 1 / attackCD * Time.deltaTime;
            if(attack.image.fillAmount <= 0)
            {
                attack.image.fillAmount = 0;
                attackIsCD = false;
                attack.interactable = true;
            }
        }
    }
    private void healcheckCD()
    {
        //Heal Cooldown
        if (healIsCD == false)
        {
            heal.image.fillAmount = 1;

        }
        else
        {
            heal.image.fillAmount -= 1 / healCD * Time.deltaTime;
            if (heal.image.fillAmount <= 0)
            {
                heal.image.fillAmount = 0;
                healIsCD = false;
                heal.interactable = true;
            }
        }
    }



    private void attackClick()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerAttack>().BuffAttack();
        }
        attackIsCD = true;
        attack.interactable = false;

    }
    private void healClick()
    {
        foreach (GameObject unit in healUnits){
            unit.GetComponent<Ally>().HealDamage(HealValue);
            
        }
        GameObject.FindGameObjectWithTag("Player").GetComponent<Player>().HealDamage(HealValue);
        HealValue += 20;
        healIsCD = true;
        heal.interactable = false;

    }
}
