using System.Collections;
using System.Collections.Generic;
using Cinemachine;
using UnityEngine;

public class CameraFollowPlayer : MonoBehaviour
{
    public GameObject tPlayer;
    public Transform tFollowTarget;
    public CinemachineVirtualCamera vcam;
    // Start is called before the first frame update
    void Start()
    {
        var vcam = GetComponent<CinemachineVirtualCamera>();
    }

    // Update is called once per frame
    void Update()
    {
        if(GameObject.FindWithTag("Player") == true)
        {
            tPlayer = GameObject.FindWithTag("Player");
            tFollowTarget = tPlayer.transform;
            vcam.LookAt = tFollowTarget;
            vcam.Follow = tFollowTarget;
        }
       
    }
}
