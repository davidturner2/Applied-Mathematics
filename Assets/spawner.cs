using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class spawner : MonoBehaviour
{
    public GameObject pathcube;
    public float spawnrate = 256f;
    float steppers=0f;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        GameObject hi = Instantiate(pathcube);
        hi.transform.parent = transform;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
      
        steppers += 100 * Time.deltaTime / 41.009f;
        if (steppers > spawnrate * Time.deltaTime / 9.009f)
        {
            steppers = 0;

            GameObject hi = Instantiate(pathcube);
            hi.transform.parent = transform;
        }


    }
}
