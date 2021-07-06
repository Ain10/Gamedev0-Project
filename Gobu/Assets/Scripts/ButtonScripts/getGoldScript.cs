using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class getGoldScript : MonoBehaviour
{
    Text displayGold;
    ScoreTrack scoreTracker;
    // Start is called before the first frame update
    void Start()
    {
        displayGold = GetComponent<Text>();
        scoreTracker = FindObjectOfType<ScoreTrack>();
    }

    // Update is called once per frame
    void Update()
    {
        displayGold.text = scoreTracker.getCurrency().ToString();
    }
}
