using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    Rigidbody2D player;
    public int speed;
    public Animator anim;
    bool touchingPlatform;
    bool IsGrounded;

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
            player.velocity = new Vector2(0, -2);
        }
        // player moves left
        if (Input.GetKey("left"))
        {
            print("player pressed left");
            // transform.position = new Vector2(transform.position.x - (speed * Time.deltaTime), transform.position.y );
            player.velocity = new Vector2(-2, 0);
        }
        // player moves right
        if (Input.GetKey("right"))
        {
            print("player pressed right");
            // transform.position = new Vector2(transform.position.x + (speed * Time.deltaTime), transform.position.y);
            player.velocity = new Vector2(2, 0);
        }
        if (Input.GetKeyDown("space") && (touchingPlatform == true))
        {
            print("player pressed spacebar");
            player.velocity = new Vector2(0, 15);
            anim.SetBool("jump", player.velocity.magnitude > 0);
        }
        else
        {
            anim.SetBool("run", player.velocity.magnitude > 0);
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
    void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            touchingPlatform = true;
        }
    }
    // mentions when the player is NOT on a platform
     void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Platform")
        {
            touchingPlatform = false;
        }
    }

}
