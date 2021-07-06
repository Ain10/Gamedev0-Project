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
        showUnitCounter++;
        if (showUnitCounter % 2 == 1)
        {
            panel[0].gameObject.SetActive(false);

        }   
        else
        {
            panel[0].gameObject.SetActive(true);

        }
    }

    public void showHideConstructs()
    {
        showConstructCounter++;
        if (showConstructCounter % 2 == 1)
        {
            panel[1].gameObject.SetActive(false);

        }
        else
        {
            panel[1].gameObject.SetActive(true);

        }
    }
}
