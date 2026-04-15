using System;
using Unity.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class cleancomment : MonoBehaviour
{
    bool movin = false;
    float tryme= 0;
    float hold= 1;
    float holdval = 1;
    Vector3 r2;
    Vector3 r1;
    public GameObject visual;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
        //get original position
        r1= transform.position;
        // get random position vector to move to
    r2 = new Vector3(UnityEngine.Random.Range(-4, 4),0, UnityEngine.Random.Range(-4, 4));
    }

    // Update is called once per frame
    void Update()
    {
        //keep the illusion of the big eye being in the sky for the camera even if the small eyes can in theory go past the big eye
        visual.transform.position=new Vector3(visual.transform.position.x,visual.transform.position.y,1996+Camera.main.transform.position.z);
        //make eye more red based on how long youve held space
        transform.GetChild(0).GetComponent<MeshRenderer>().material.color = new Vector4(1,1+1-holdval,1+1-holdval,1);
        transform.GetChild(1).GetComponent<MeshRenderer>().material.color = new Vector4(1,1+1-holdval,1+1-holdval,1);
        // increase scalar value when not moving 
        if (Input.GetKey(KeyCode.Space)){
            if (!movin){
            if(hold<=13)
            hold+= 1.5f*hold*Time.deltaTime;
            
            holdval = hold;
        }
        }
        //start moving if space is released
        if (Input.GetKeyUp(KeyCode.Space)) {
    movin = true;
}
    //Dot product check to see if eye is looking at the big eye both vectors are magnitude 1
    float eye=Vector3.Dot(transform.forward,Vector3.forward);
        // add visual effect to represent this
        if (eye >= 0.67)
        {
            RenderSettings.skybox.SetColor("_SkyTint", Color.red);
            visual.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Vector4(0,1,1,1));
        }
        else
        {
            RenderSettings.skybox.SetColor("_SkyTint", Color.black);
            visual.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Vector4(1,1,1,1));
        }
    }
    void FixedUpdate()
    {
        if (movin)
        {
            // a lerp value that uses time
            tryme+=Time.deltaTime;

            //Scalar multiplication how far the eyes move depends on how long you hold space
            //look at the new direction based on the old direction
            //Vector Addition to look at the new value based on the old value
            transform.forward=Vector3.Lerp(transform.forward,r1+2*hold*r2-r1,tryme);
            //Vector addition add new position vector to old position
            transform.position=Vector3.Lerp(transform.position,r1+2*hold*r2,tryme);
            //lerp color of eye back to normal
            holdval=Mathf.Lerp(hold,1,tryme);
            if (tryme >= 1)
            {   
                //reset lerp values add new position record old position and stop moving
                tryme=0;
                movin = false;
                r1 = transform.position;
                hold=1;
                r2 = new Vector3(UnityEngine.Random.Range(-4, 4),0, UnityEngine.Random.Range(-4, 4));
            }
        }

    }
}
