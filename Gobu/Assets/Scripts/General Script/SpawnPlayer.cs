using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class SpawnPlayer : MonoBehaviour
{
    [SerializeField] GameObject player;
    ScoreTrack score;
    // Start is called before the first frame update
    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        //float life = score.getLives();
        if(GameObject.FindGameObjectWithTag("Player") == false)
        {
            Instantiate(player, new Vector3(transform.position.x, transform.position.y,0), Quaternion.identity);
        }
     }
    
}
