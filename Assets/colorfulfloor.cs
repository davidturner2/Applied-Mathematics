using System;
using UnityEngine;

public class colorfulfloor : MonoBehaviour
{
    public Transform person;
    //Color a = new Vector4(1f,1f,1f,1f);
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    //GetComponent<Renderer>().material.color = a;

    }

    // Update is called once per frame
    void Update()
    {
        Vector3 m = new Vector3(person.position.x,person.position.z,0);
       
        float theta = Mathf.Atan2(m.y,m.x);
        if (theta < 0)
        {
            theta+=2*Mathf.PI;
        }
        float angle = theta*Mathf.Rad2Deg;
        float r = Vector2.Distance(new Vector2(transform.position.x,transform.position.z), new Vector2(Mathf.Clamp(m.x,transform.position.x-transform.localScale.x/4f,transform.position.x+transform.localScale.x/4f),Mathf.Clamp(m.y,transform.position.z-transform.localScale.z/4f,transform.position.z+transform.localScale.z/4f)));
       print(r);
       GetComponent<Renderer>().material.color=Color.HSVToRGB(angle/360f,r/10f,1);
    }

    
}
