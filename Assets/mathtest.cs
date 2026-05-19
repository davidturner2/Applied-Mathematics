using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using UnityEngine.UI;
using Unity.VisualScripting;
using UnityEngine.AI;

public class mathtest : MonoBehaviour
{
    public TMP_InputField answer;
    public TMP_Text questoion;
    Vector3 v1 = Vector3.zero;
    Vector3 v2 = Vector3.zero;
    float theAnswer = 0;
    // Start is called before the first frame update
    void Start()
    {

        //spawn first vector
        v1 = new Vector3(Random.Range(0,10),Random.Range(0,10),Random.Range(0,10));
        v2 = new Vector3(Random.Range(0,10),Random.Range(0,10),Random.Range(0,10));
        // the answer of the 2 vectors dotted
        theAnswer = Vector3.Dot(v1,v2);
        questoion.text = "What does Vector3.Dot(" + v1+"\n,"+v2+") equal?";
    }

    // Update is called once per frame
    void Update()
    {
    }
    public void test(){
        // if theres no answer fail the test
        if (answer.text == ""){
                        fail();

        }else{
            //if answer is correct when parsed then go to next scene
            //else fail
        if (float.Parse(answer.text) == theAnswer){
                SceneManager.LoadScene(3);
        }else{
            fail();
        }
        }
    }
    //reload scene on fail
      void fail()
        {
           
                SceneManager.LoadScene(1);
        }
}
