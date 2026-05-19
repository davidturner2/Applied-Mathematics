using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;


using UnityEngine.UIElements;
using Unity.VisualScripting;

public class example : MonoBehaviour
{
    bool stop = true;
    bool toy = true;
    public int e = 0;
    public int w = 0;
    public TextMeshProUGUI text;
        public TextMeshProUGUI text2;

    public GameObject win;
        public GameObject win2;

        public GameObject lose;

    Rigidbody r;
    float ahh = 0f;
    public float boost = 1f;
    Vector3 direction;
    bool left= false;
    public GameObject b;
    // Start is called before the first frame update
    void Start()
    {
        r = GetComponent<Rigidbody>();
        b.GetComponent<ParticleSystem>().Stop();
direction =Vector3.zero;
    }
    void Update(){
         if(Input.GetKey("space")){
                    SceneManager.LoadScene(1);

        }
    }
    IEnumerator asddf(){
        yield return new WaitForSeconds(5f);
        win.SetActive(false);


    }
    // Update is called once per frame
    void FixedUpdate()
    {   if(stop){
        if(e>3 && toy){
            toy = false;
        win.SetActive(true);
        StartCoroutine("asddf");
        }
        if(w>=265){
win2.SetActive(true);
        }
    // board game controls to move by one step in vector
        if (Input.GetKey("w"))
        {
                    //r.AddForce(direction * 20 * boost);

            r.linearVelocity =transform.rotation * (Vector3.forward*20*boost);
       
    
        }
         if (Input.GetKey("a"))// && !Input.GetKey("w")&& !Input.GetKey("s"))
        {
            transform.Rotate(new Vector3(0,-5,0));
     
            //r.velocity  =Quaternion.Inverse(transform.rotation) *  Vector3.right*20*boost;
          
        }
           if (Input.GetKey("d"))//&& !Input.GetKey("w")&& !Input.GetKey("s"))
        {
                        transform.Rotate(new Vector3(0,5,0));

           // r.velocity  =Quaternion.Inverse(transform.rotation) *  Vector3.left*20*boost;
        
        }
        if (Input.GetKey("x"))
        {
                    r.linearVelocity = r.linearVelocity/1.202f; //(direction * 20 * boost);
        }
        if (Input.GetKey("s"))
        {
            
                       r.linearVelocity =transform.rotation * (Vector3.back*20*boost);

       
           if (Input.GetKey("d") &&Input.GetKey("s"))
        {
            //r.velocity  = Quaternion.Inverse(transform.rotation) *  Vector3.forward*20*boost+Vector3.left*20*boost;
        }
            
            //direction = Vector3.zero; //(transform.position-Vector3.back*100);
        }
        if(Input.GetKey("q")){
            r.linearVelocity = new Vector3(0,1,0) * 20 * boost;
        }
           if(Input.GetKey("e")){
            r.linearVelocity = new Vector3(0,-1,0) * 20 * boost;
        }
        if (Input.GetKey(KeyCode.LeftShift))
        {
                        b.SetActive(true);

            /*if( b.GetComponent<ParticleSystem>().isPlaying==false){
            b.GetComponent<ParticleSystem>().Play();
            }*/
            if (direction == Vector3.zero)
            {
                direction = Vector3.back;


            }
            boost = 2f+ahh/400;
        }
        else 
        {
            b.SetActive(false);
            boost = 1f;
        }
       if (Input.GetKey("x")){
                r.linearVelocity = r.linearVelocity/1.302f; 

       }
        r.linearVelocity = r.linearVelocity/1.0602f; 
    }
    }

    private void OnCollisionEnter(Collision other){
        if ( Vector3.Magnitude(other.gameObject.GetComponent<BoxCollider>().bounds.size)
        >=Vector3.Magnitude(gameObject.transform.GetChild(0).GetComponent<BoxCollider>().bounds.size)){
            print("bigger");
           if( other.gameObject.tag != "wall"){
            //Destroy(gameObject.transform.GetChild(0).gameObject);
            transform.GetChild(0).GetComponent<MeshRenderer>().enabled = false;
                        transform.GetChild(0).GetComponent<BoxCollider>().enabled = false;
            b.SetActive(false);
            transform.position = new Vector3(9999,9999,9999);
            stop = false;
            lose.SetActive(true);
            }
        }else{
            if(other.gameObject.tag == "win"){
                    e++;
                    text2.text = "enemy:"+e+"/4";
            }
             if(other.gameObject.tag == "wall"){
                    w++;
            }
            ahh += Vector3.Magnitude(other.gameObject.GetComponent<BoxCollider>().bounds.size);
            text.text = "total value of things abducted:"+Mathf.RoundToInt(ahh);
                        Destroy(other.gameObject);

            gameObject.transform.GetChild(0).transform.localScale +=new Vector3(0.25f,0.25f,0.25f);
                  gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).transform.localScale +=new Vector3(0.25f,0.25f,0.25f);
                  gameObject.transform.GetChild(0).gameObject.transform.GetChild(1).transform.position +=new Vector3(0,0,0.1f*0.25f);

        }
    }
}
