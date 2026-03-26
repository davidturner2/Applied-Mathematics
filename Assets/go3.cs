using System;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class go3 : MonoBehaviour
{
    //  public GameObject cube2;
    Vector2 xinterval = new Vector2(-9, 6);
    //public List<Transform> cubes;
    // public List<Transform> cubes2;
    public float step = 0.003f;
    float steppers = 0f;
    float r;
    Vector3 r2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        float x = step + xinterval.x + steppers;
        float y = 1 - ((1f) / (60f)) * x * (x + 4) * (x - 6);
        transform.localPosition = new Vector3(x, y, 0);
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(r2 * r * Time.deltaTime);
        steppers += 100 * Time.deltaTime / 41.009f;
        float t = steppers;




        float x = step + xinterval.x + steppers;
        float y = F(x);
        float yprime = G(x);

        float j = -2.3f;

        float F(float x)
        {
            return 1- ((1f) / (60f)) * x * (x + 4f) * (x - 6f);
        }

        float G(float x)
        {
            return -(3f*x*x)/60f+2f*x/60f+0.4f;
        }


        
        
        float p = F(j) - (1 / G(j)) * (x - j);

        Vector3 normal = (new Vector3(0,0, y-(1f/yprime)*(0f-x))-new Vector3(1f,0, y-(1f/yprime)*(1f-x))).normalized;
        print(normal);
        //transform.localRotation = Quaternion.Euler(new Vector3(70f * math.sin(x * 3), 0, normal));
        transform.localRotation = Quaternion.Euler(normal);
        transform.localPosition = new Vector3(x, y, 0);

        if (x > xinterval.y)
        {
            Destroy(gameObject);
        }

    }
}
