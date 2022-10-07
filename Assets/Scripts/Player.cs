using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D player;
    [SerializeField] public float speed;
    public Animator anim;
    bool touchingPlatform;
    private bool grounded;

    // Start is called before the first frame update
    void Start()
    {
        // grabs the references
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 20;
    }

    // Update is called once per frame
    void Update()
    {
        // player moves up
        if (Input.GetKey("up"))
        {
            print("player pressed up");
            // transform.position = new Vector2(transform.position.x, transform.position.y + (speed * Time.deltaTime));
       //   player.velocity = new Vector2(0, 2);
        }
        // player moves down
        if (Input.GetKey("down"))
        {
            print("player pressed down");
            // transform.position = new Vector2(transform.position.x, transform.position.y - (speed* + Time.deltaTime));
           // player.velocity = new Vector2(0, -2);
        }
        // player moves left and right
        {
            float horizontalInput = Input.GetAxis("Horizontal");
            player.velocity = new Vector2(horizontalInput * speed, player.velocity.y);
        // flips the player left or right
            if (horizontalInput > 0.01f)
                transform.localScale = Vector3.one;
           else if (horizontalInput < -0.01f)
                transform.localScale = new Vector3(-1, 1, 1);
        }
        if (Input.GetKeyDown("space") && touchingPlatform)
        {
            print("player pressed spacebar");
            Jump();
            //Set animator parameters
            anim.SetBool("run", )
            anim.SetBool("jump", false);
        }
        if (Input.GetKey("q"))
        {
            print("player is attacking!");
            anim.SetBool("attack", true);
            
        }
        else
        {
            anim.SetBool("attack", false);
        }
    }
    // tells the player to stick to a platform
    void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            touchingPlatform = true;
            grounded = true;
        }
    }
    // mentions when the player is NOT on a platform
     void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            touchingPlatform = false;
            grounded = false;
        }
    }
    private void Jump()
    {
        player.velocity = new Vector2(player.velocity.x, speed);
        grounded = false;
    }
}
