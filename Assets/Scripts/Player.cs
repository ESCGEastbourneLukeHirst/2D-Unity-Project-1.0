using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D player;
    public float speed;
    public Animator anim;
    bool touchingPlatform;
    bool grounded;
    HelperScript helper;

    // Start is called before the first frame update
    void Start()
    {
        // grabs the references
        player = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        speed = 20;
        helper = gameObject.AddComponent<HelperScript>();
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
        // flips the player right, and moves the player right
        {
            if (Input.GetKey("right"))
            {
                player.velocity = new Vector2(5, 0);
                helper.FlipObject(false);
            }
            // flips the player left, and moves the player left
            if (Input.GetKey ("left"))
            {
                player.velocity = new Vector2(-5, 0);
                helper.FlipObject(true);
            }
        }
        // tells the player to jump, and apply the running animation when NOT Jumping.
        if (Input.GetKeyDown("space") && touchingPlatform)
        {
            print("player pressed spacebar");
            player.velocity = new Vector2(0, 15);
        }
        else
        {
            anim.SetBool("run", player.velocity.magnitude != 0);
        }
        // tells the player to perform the player attack animation
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
}
