using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class killingtoday : MonoBehaviour
{
        public GameObject win;
    public GameObject lose;
    public GameObject asadssffs;
    int soccer = 0;
    public TextMeshProUGUI score;
    public Vector3 movetothis;
    float steppers;
    bool yuh = false;
    public bool diedied= false;
    // Start is called before the first frame update
    void Start()
    {
         score.text = soccer+"/"+"5 Objects destroyed";
         movetothis = transform.position;
               //new Vector3(0f, 0.35f, 0f);
               GetComponent<LineRenderer>().widthMultiplier	= 5;

    }
     
    // Update is called once per frame
    void Update()
    {
         //map position to moyse position
        transform.position = new Vector3(map(Input.mousePosition.x,0,Screen.width,150.4f,550),transform.position.y,transform.position.z);
        if(yuh){
        steppers += 1700*Time.deltaTime/9.009f;
         movetothis = transform.position;
                Vector3 ra = new Vector3(movetothis.x - 0.3f, movetothis.y + 0.3f, movetothis.z);
        RaycastHit down;

        if (Physics.Raycast(ra, transform.TransformDirection(Vector3.forward), out down, steppers)&&!diedied)
        {
            reseter(ra);
                // if ray cast colides with object with the tag player then lose
            if(down.collider.gameObject.tag == "Player"){
                                    score.text="";

                Destroy(gameObject);
               Destroy( asadssffs);
                                    lose.SetActive(true);
                    // move camera away from everytghing
                Camera.main.transform.position+=Vector3.forward*9999;
            }else{
                    //increasr the scoerre
                soccer++;
                    // set the score text 
                score.text = soccer+"/"+"5 Objects destroyed";
                if(soccer >= 5){
                    score.text="";
                    win.SetActive(true);
                                    Camera.main.transform.position+=Vector3.forward*9999;
                    Destroy(gameObject);
                }
            }
            
            Destroy(down.collider.gameObject);
           


        }
        else
        {
            Debug.DrawRay(ra, transform.TransformDirection(Vector3.forward) * steppers, Color.white);
                
            GetComponent<LineRenderer>().startColor = Color.yellow;
            GetComponent<LineRenderer>().endColor = Color.blue;

            GetComponent<LineRenderer>().SetPosition(0,ra);//, , Color.yellow);
                // increase line renderer lengtgh by steppers keep going up
            GetComponent<LineRenderer>().SetPosition(1,ra+transform.TransformDirection(Vector3.forward) * steppers);
                //maximum height is 230 reset everything and the colorss
            if(steppers>=230){
                            reseter(ra);

            }
        }
        if(diedied){
            Destroy(gameObject);
        }
        }
        // whhen click set yuh to true change material color
        if(Input.GetMouseButtonDown(0)){
             GetComponent<Renderer>().material.SetColor("_Color", Color.blue);
            yuh = true;
        }
    }
    void reseter(Vector3 rrr){
         steppers = 0;
            GetComponent<Renderer>().material.SetColor("_Color", Color.white);
            yuh = false;
            GetComponent<LineRenderer>().SetPosition(1,rrr);//, , Color.yellow);
    }
    float map (float value, float from1, float to1, float from2, float to2) {
	return (value - from1) / (to1 - from1) * (to2 - from2) + from2;
    }
}
