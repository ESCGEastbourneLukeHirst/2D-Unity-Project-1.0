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
    public GameObject fireball;

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
        helper.DoRayCollisionCheck();

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


        
        grounded = true;

        // tells the player to jump, and apply the running animation when NOT Jumping.
        if (Input.GetKeyDown("space") && grounded)
        {
            print("Player pressed spacebar");
            anim.SetBool("jump", true);
            grounded = false;

            player.velocity = new Vector3( player.velocity.x, 10, 0);

        }
        else
        {
            anim.SetBool("run", player.velocity.magnitude > 0);
            grounded = true;
            anim.SetBool("jump", false);
        }
        // tells the player to perform the player attack animation
        int moveDirection = 1;
        if (Input.GetKeyDown("q"))
        {
            print("player is attacking!");
            anim.SetBool("attack", true);
            // Instantiate the fireball at the position and rotation of the player
            GameObject clone;
            clone = Instantiate(fireball, transform.position, transform.rotation);
            
            // get the rigidbody component
            Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

            // set the velocity
            rb.velocity = new Vector3(15 * moveDirection, 0, 0);

            //set the position close to the player
            rb.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z + 1);    
        }
        else
        {
            anim.SetBool("attack", false);
        }

    }
    // tells the player to stick to a platform
   //   void OnCollisionEnter2D(Collision2D collision) 
        
   //       if (collision.gameObject.tag == "Platform")
            
   //           touchingPlatform = true;
   //           grounded = true;
            
        
        // mentions when the player is NOT on a platform
   //    void OnCollisionExit2D(Collision2D collision)
        
   //       if (collision.gameObject.tag == "Platform")
            
     //         touchingPlatform = false;
       //       grounded = false;
            
        
}
