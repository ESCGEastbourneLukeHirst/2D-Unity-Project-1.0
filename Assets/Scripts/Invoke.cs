using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Invoke : MonoBehaviour
{
    public GameObject marble;


    void Start()
    {
        Invoke("SpawnObject", 3);
    }

    void SpawnObject()
    {
        Instantiate(marble, new Vector3(8, 2, 0), Quaternion.identity);
    }
}
