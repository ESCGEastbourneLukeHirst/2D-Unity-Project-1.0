using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    Rigidbody2D rb;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(CubeCorountine());
    }
    IEnumerator CubeCorountine()
    {
        int count = 0;
        while (count < 5)
        {
            rb.velocity = new Vector2(-5, 0);
            yield return new WaitForSeconds(2.5f);
            rb.velocity = new Vector2(5, 0);
            yield return new WaitForSeconds(2.5f);
            rb.velocity = new Vector2(0, 0);
            yield return new WaitForSeconds(1);
            count++;
        }
        if (count > 5)
        {
            rb.velocity = new Vector2(0, 0);
            yield return new WaitForSeconds(2);
            yield return null;
            StopCoroutine(CubeCorountine());
        }
        }

    }
