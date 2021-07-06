using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] Rigidbody2D player;
    [SerializeField] float speed = 10f, jumpForce;
    [SerializeField] bool isGrounded;
    [SerializeField] Transform groundCheckCollider;
    [SerializeField] LayerMask groundLayer;
    const float groundCheckRadius = 0.2f;
    float xDir;

    // Update is called once per frame
    void Update()
    {
        xDir = Input.GetAxisRaw("Horizontal");
        if (Input.GetButtonDown("Jump")) jump();
        
    }

    private void FixedUpdate() {
        groundCheck();
        move(xDir);
    }

    // void dash(KeyCode key){
    //     if(Input.GetKeyDown(KeyCode.A) && firstButtonPressed) {
    //          if(Time.time - timeOfFirstButton < 0.5f) {
    //              Debug.Log("DoubleClicked");
    //          } else {
    //              Debug.Log("Too late");
    //          }
 
    //          reset = true;
    //      }
 
    //      if(Input.GetKeyDown(KeyCode.A) && !firstButtonPressed) {
    //          firstButtonPressed = true;
    //          timeOfFirstButton = Time.time;
    //      }
 
    //      if(reset) {
    //          firstButtonPressed = false;
    //          reset = false;
    //      }
    // }

    void move(float direction){
        if(direction == 1) transform.localScale = new Vector3(1.3f, 4.7f, 1f);
        if (direction == -1) transform.localScale = new Vector3(-1.3f, 4.7f, 1f);
        if (isGrounded) speed = 5;
        else speed = 3;
        transform.position += new Vector3(direction * speed * Time.fixedDeltaTime, 0,0);
    }

    void jump(){
        if (isGrounded) player.velocity = new Vector2(0f, 1) * jumpForce;
    }

    void groundCheck(){
        isGrounded = false;
        Collider2D[] collider = Physics2D.OverlapCircleAll(groundCheckCollider.position, groundCheckRadius, groundLayer);
        if (collider.Length > 0) isGrounded = true;
    }
}
