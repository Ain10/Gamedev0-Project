using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SummonUnit : MonoBehaviour
{
    [SerializeField] List<GameObject> units;
    [SerializeField] List<Button> ButtonSummon;
    [SerializeField] Transform spawn;
    public int GoblinPrice, ArcherPrice, HobgoblinPrice, OrcPrice;
    ScoreTrack gold;
    private void Start()
    {
        gold = FindObjectOfType<ScoreTrack>();
    }
    void Update()
    {
        checkEnable();
        checkDisable();
    }

    private void checkDisable()
    {
        if (gold.getCurrency() <= OrcPrice)
        {
            ButtonSummon[3].interactable = false;
        }
        if (gold.getCurrency() <= HobgoblinPrice)
        {
            ButtonSummon[2].interactable = false;
        }
        if (gold.getCurrency() <= ArcherPrice)
        {
            ButtonSummon[1].interactable = false;
        }
        if (gold.getCurrency() <= GoblinPrice)
        {
            ButtonSummon[0].interactable = false;
        }
    }
    private void checkEnable()
    {
        if (gold.getCurrency() >= OrcPrice)
        {
            ButtonSummon[3].interactable = true;
        }
        if (gold.getCurrency() >= HobgoblinPrice)
        {
            ButtonSummon[2].interactable = true;
        }
        if (gold.getCurrency() >= ArcherPrice)
        {
            ButtonSummon[1].interactable = true;
        }
        if (gold.getCurrency() >= GoblinPrice)
        {
            ButtonSummon[0].interactable = true;
        }
    }
    public void summonGoblin()
    {
        Instantiate(units[0], spawn.position, Quaternion.identity);
        gold.setCurrency(gold.getCurrency() - GoblinPrice);
    }
    public void summonArcher()
    {
        Instantiate(units[1], spawn.position, Quaternion.identity);
        gold.setCurrency(gold.getCurrency() - ArcherPrice);
    }
    public void summonHob()
    {
        Instantiate(units[2], spawn.position, Quaternion.identity);
        gold.setCurrency(gold.getCurrency() - HobgoblinPrice);
    }
    public void summonOrc()
    {
        Instantiate(units[3], spawn.position, Quaternion.identity);
        gold.setCurrency(gold.getCurrency() - OrcPrice);
    }
}
