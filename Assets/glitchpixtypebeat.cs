using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class glitchpixtypebeat : MonoBehaviour
{
    float steppers =0;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //changing colors of light
        steppers+=0.0004f;
        Color asdf = new Vector4(255f/255f, 100f/255f*(1/Mathf.Sin(steppers)), 0.8f*Mathf.Cos(steppers),255f/255f);
    GetComponent<Light>().color = asdf;
    }
}
