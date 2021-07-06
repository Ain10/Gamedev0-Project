using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moveForward : MonoBehaviour
{
    float time, effectTime;
    public Rigidbody2D rb;
    public float forwardForce = 2000f, speed;


    // Start is called before the first frame update
    void Start()
    {
        time = Time.time;
        effectTime = time + 0.7f;
        rb.velocity = -transform.right * speed;
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time >= effectTime){
            Debug.Log("destroy");
            Destroy(this.gameObject);
        }

        // rb.AddForce(new Vector2(-forwardForce * Time.deltaTime, 0 ));
    }
}
