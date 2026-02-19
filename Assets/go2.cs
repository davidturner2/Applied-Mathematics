using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class go2 : MonoBehaviour
{
    //  public GameObject cube2;
    Vector2 xinterval = new Vector2(-9, 14);
    //public List<Transform> cubes;
    // public List<Transform> cubes2;
    public float step = 0.003f;
    float steppers = 0f;
    float r;
    Vector3 r2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        r = UnityEngine.Random.Range(100f, 200f);
        if (UnityEngine.Random.Range(0f, 50f) < 25f)
        {
            r *= -1;
        }
        r2 = new Vector3(UnityEngine.Random.Range(0, 2), UnityEngine.Random.Range(0, 2), UnityEngine.Random.Range(1, 2));

        float x = step + xinterval.x + steppers;
        float y = step + xinterval.x + steppers;
        float z = (10f / 20f) * steppers;
        transform.localPosition = new Vector3(2f * math.cos(x), z, 2f * math.sin(y));

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(r2 * r * Time.deltaTime);
        steppers += 100 * Time.deltaTime / 41.009f;





        float x = step + xinterval.x + steppers;
        float y = step + xinterval.x + steppers;
        float z = (10f/20f)*steppers;
        transform.localPosition = new Vector3(2f*math.cos(x), z, 2f * math.sin(y));

        if (y > xinterval.y)
        {
            Destroy(gameObject);
        }

    }
}
