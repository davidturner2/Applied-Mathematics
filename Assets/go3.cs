using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

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





        float x = step + xinterval.x + steppers;
        float y = 1 - ((1f) / (60f)) * x * (x + 4) * (x - 6);
        transform.localRotation = Quaternion.Euler(new Vector3(40f * math.sin(x * 3), 0, 90));

        transform.localPosition = new Vector3(x, y, 0);

        if (x > xinterval.y)
        {
            Destroy(gameObject);
        }

    }
}
