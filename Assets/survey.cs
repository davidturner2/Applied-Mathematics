using System;
using System.Collections.Generic;
using System.Drawing;
using Unity.Mathematics;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;

public class survey : MonoBehaviour
{
    public GameObject cube;
    Vector2 xinterval = new Vector2(-15,15);
    public List<Transform> cubes;
    public float step = 0.003f;
    public float a,b,c,d,e,f,g;
    float steppers = 0f;
    int asmr = 9;
    float[] rpoints;
    float[] curre;
    float[] lerps;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        curre = new float[asmr];
        rpoints = new float[asmr];
        lerps  = new float[asmr];
     for (int i = 0; i < curre.Length; i++)
            {
                rpoints[i] = UnityEngine.Random.Range(-5f,5f);
            }
        for (float i = xinterval.x; i < xinterval.y; i+=step)
        {
            GameObject hi = Instantiate(cube);
            cubes.Add(hi.transform);
            hi.GetComponent<MeshRenderer>().material.color = new Vector4(map(i,0,50,0,1),0,0,1);
            hi.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Vector4(map(i, 0, 50, 0, 1), 0, 0, 1));

            //Debug.Log(map(i,-15,15,-5,10)+"Mapping from -5 to 10");
        }
    }

    float map(float val, float o1,float o2, float n1, float n2)
    {
        // recreated the map function from processing by converting the values into 0 to 1 using the old min and max and using a lerp fuction to map it the new min and max
        return math.lerp(n1,n2,(val-o1)/o2);
//return 1;
    }
    // Update is called once per frame
    void FixedUpdate()
    {   
        
        steppers += 100*Time.deltaTime/9.009f;  

 /*       if(steppers> 10000 * Time.deltaTime / 9.009f)
        {
            print("dfojd");
            steppers = 0;
            for (int i = 0; i < curre.Length; i++)
            {
                curre[i]=lerps[i];
                rpoints[i] = UnityEngine.Random.Range(0,10f);
            }

        }    */
        for(int i = 0; i<curre.Length;i++){   
        lerps[i] = math.lerp(curre[i],rpoints[i],steppers/(10000 * Time.deltaTime / 9.009f));
        }
       
        for (int i = 0; i<cubes.Count;i++){
            float x = i*step+xinterval.x;
            float s = 1;
            float s2 = 1;
            for (int j = 0; j < curre.Length; j++)
            {
                s*=math.sin(x+lerps[j]); 
                s2*=math.cos(x+lerps[j]*0.5f);
            }
            float y = math.clamp(-50.1f*s,-20,20);//13+(x*x*-1/10f);
            cubes[i].position = new Vector3(x,y,30*s2*y/2.2143343f);
        }

    }
}
