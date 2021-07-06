using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ConstructDefenseScript : MonoBehaviour
{
    [SerializeField] List<GameObject> construct;
    [SerializeField] List<Button> buttonConstruct;
    Transform location;
    private int cannonCounter = 0, barricadeCounter = 0;
    public int BarricadePrice, CannonPrice;
    ScoreTrack gold;
    void Start()
    {
        gold = FindObjectOfType<ScoreTrack>();
        
    }

    // Update is called once per frame
    void Update()
    {
        if (GameObject.FindGameObjectWithTag("Player"))
        {
            location = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();
        }
        checkEnable();
        checkDisable();
    }
    public void cannonConstruct()
    {
        if (cannonCounter != 3 && location != null)
        {
            Instantiate(construct[0], location.position, Quaternion.identity);
            gold.setCurrency(gold.getCurrency() - CannonPrice);
            cannonCounter++;
        }
    }
    public void barricadeConstruct()
    {
        if (barricadeCounter != 5 && location != null)
        {
            Instantiate(construct[1], location.position, Quaternion.identity);
            gold.setCurrency(gold.getCurrency() - BarricadePrice);
            barricadeCounter++;
        }

    }
    private void checkDisable()
    {

        if (gold.getCurrency() <= CannonPrice)
        {
            buttonConstruct[1].interactable = false;
        }
        if (gold.getCurrency() <= BarricadePrice)
        {
            buttonConstruct[0].interactable = false;
        }
    }
    private void checkEnable()
    {

        if (gold.getCurrency() >= CannonPrice)
        {
            buttonConstruct[1].interactable = true;
        }
        if (gold.getCurrency() >= BarricadePrice)
        {
            buttonConstruct[0].interactable = true;
        }
    }
}
