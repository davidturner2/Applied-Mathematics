using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using Unity.VisualScripting;
using UnityEngine;

public class change : MonoBehaviour
{
    Color a = new Vector4(1f,1f,1f,1f);
    float um;
    bool after;
    // Start is called before the first frame update
    void Start(){
     a.g = 1f;
    a.b = 1f;
    a.r = 1f;

    }
    void Update()
    {
    um = 6.01f*Time.deltaTime;
    GetComponent<Renderer>().material.color = a;
    
    if(after){
    a = Vector4.Lerp(a,new Vector4(166f/255f,229f/255f,249f/255f,1),um);
    
    if (Vector4.Distance(a, new Vector4(166f/255f,229f/255f,249f/255f,1))<0.01)
        after = false;
    }
    else{
    a = Vector4.Lerp(a,new Vector4(1,1,1,1),um);

    }
    }

  

    // Update is called once per frame

    private void OnCollisionEnter(Collision other)
    {
        a.b = 0f;
        a.r = 0f;
        a = new Vector4(110f/255f,242f/255f,73f/255f,1);
        after = true;
   }

private void OnTriggerEnter(Collider other)
    {
        a.b = 0f;
        a.r = 0f;
        a = new Vector4(110f/255f,242f/255f,73f/255f,1);
        after = true;
   }




// ill use this 
    // private float easydamp(float x){
    //     if (x == 0){
    //         return 1;
    //     }
    //     else if(x<=2*Mathf.PI){
    //         return Mathf.Sin(x)/x;
    //     }
    //     else{
    //         return 1;
    //     }

    // }

}
