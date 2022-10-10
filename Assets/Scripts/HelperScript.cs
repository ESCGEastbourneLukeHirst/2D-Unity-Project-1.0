using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HelperScript : MonoBehaviour
{
    LayerMask groundLayerMask;
    bool grounded;

    void Jump()
    {
        if (grounded == false)
        {
            return;
        }
        else
        {
            grounded = true;
        }
    }

    private void Start()
    {
        groundLayerMask = LayerMask.GetMask("Ground");
    }
    public void DoRayCollisionCheck()
    {
        float rayLength = 0.6f;
        Vector3 offset = new Vector3(0, -1, 0);

        // cast a ray downward of length 1
        RaycastHit2D hit = Physics2D.Raycast(transform.position+offset, -Vector2.up, rayLength, groundLayerMask);

        Color hitColor = Color.white;

        if(hit.collider.tag != null)
        {
            hitColor = Color.green;

        }
        Debug.DrawRay(transform.position + offset, (-Vector2.up* rayLength), hitColor);
    }
    public void FlipObject(bool flip)
    {
        // get the SpriteRenderer component
        SpriteRenderer sr = gameObject.GetComponent<SpriteRenderer>();

        if (flip == true)
        {
            sr.flipX = true;
        }
        else
        {
            sr.flipX = false;
        }
    }
}
