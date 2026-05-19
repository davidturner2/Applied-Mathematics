using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;

public class imgonnakillyoutoo : MonoBehaviour
{
    public bool startpooping = false;
    float x,y,z;
    public GameObject target;
    // Start is called before the first frame update
    void Start()
    {
       
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // if start pooping then move in the direction of the target
        if (startpooping){
           
            if(target.GetComponent<example>().boost == 2f){
                         gameObject.GetComponent<Rigidbody>().linearVelocity = (target.transform.position + new Vector3(0,-3,0) - transform.position).normalized * 30;
                GetComponent<Animator>().speed = 55;
            }else{
         gameObject.GetComponent<Rigidbody>().linearVelocity = (target.transform.position + new Vector3(0,-3,0) - transform.position).normalized * 16;
                GetComponent<Animator>().speed = 1;

            }

        }else{
                            GetComponent<Animator>().speed = 0.5f;

            // gameObject.transform.position = new Vector3(z+50*Mathf.Sin(Time.deltaTime),y+50*Mathf.Sin(Time.deltaTime),z+50*Mathf.Sin(Time.deltaTime));
        }
    }



}
