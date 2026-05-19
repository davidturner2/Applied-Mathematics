using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dontkillme : MonoBehaviour
{
    float startx;
    public float range = 200f;
        float starty;
float steppers = 0f;
    // Start is called before the first frame update
    void Start()
    {
        startx = transform.position.x;
        starty = transform.position.y;
    }

    // Update is called once per frame
    void FixedUpdate()
    {
                transform.Rotate(Vector3.up*1.4f);

                steppers += 10*Time.deltaTime/9.009f;

        transform.position = new Vector3(startx+range*Mathf.Sin(steppers),starty+2*Mathf.Sin(Random.Range(0,9999)),transform.position.z);
    }
}
