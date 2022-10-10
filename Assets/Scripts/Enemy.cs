using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float x;
    public float y;
    public GameObject diamond;
    public float minDistance;
    private Rigidbody2D rb;

    // Start is called before the first frame update
    void Start()
    {

    }

        // Update is called once per frame
        void Update()
        {
            x = player.transform.position.x;
            y = player.transform.position.y;
            int moveDirection = 1;
            if (player.transform.position == new Vector3(x, y, 0))
            {
                // Instantiate the fireball at the position and rotation of the player
                GameObject clone;
                clone = Instantiate(diamond, transform.position, transform.rotation);

                // get the rigidbody component
                Rigidbody2D rb = clone.GetComponent<Rigidbody2D>();

                // set the velocity
                rb.velocity = new Vector3(15 * moveDirection, 0, 0);

                //set the position close to the player
                rb.transform.position = new Vector3(transform.position.x, transform.position.y + 2, transform.position.z + 1);

            }
        }
    }
