using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InvokeRepeating : MonoBehaviour
{
    public GameObject diamond;


    void Start()
    {
        InvokeRepeating("SpawnObject", 2, 1);
        Destroy(diamond, 3.0f);
    }

    void SpawnObject()
    {
        float x = Random.Range(-2.0f, 2.0f);
        float z = Random.Range(-2.0f, 2.0f);
        Instantiate(diamond, new Vector3(x, 6, z), Quaternion.identity);
    }
}
