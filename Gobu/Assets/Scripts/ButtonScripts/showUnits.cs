using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System;

public class showUnits : MonoBehaviour
{
    private int showUnitCounter = 0, showConstructCounter = 0;
    public List<GameObject> panel;
    


    public void showHideUnits()
    {
        if (showUnitCounter % 2 == 1)
        {
            panel[0].gameObject.SetActive(false);
            showUnitCounter++;
        }   
        else
        {
            panel[0].gameObject.SetActive(true);
            showUnitCounter++;
        }
    }

    public void showHideConstructs()
    {
        if (showUnitCounter % 2 == 1)
        {
            panel[1].gameObject.SetActive(false);
            showConstructCounter++;
        }
        else
        {
            panel[1].gameObject.SetActive(true);
            showConstructCounter++;
        }
    }
}
