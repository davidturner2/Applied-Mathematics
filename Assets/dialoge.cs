using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialoge : MonoBehaviour
{
    public GameObject disable;
    public GameObject enable;

    public GameObject camera1;
    public GameObject cameratoomove;
    public GameObject disableplayer;
    bool fart = false;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (fart)
        {
            cameratoomove.transform.position = Vector3.MoveTowards(cameratoomove.transform.position, camera1.transform.position, 20.9089f * Time.deltaTime);
            cameratoomove.transform.rotation = Quaternion.RotateTowards(cameratoomove.transform.rotation, camera1.transform.rotation, 20.9089f * Time.deltaTime);
        }
    }
public void asdf() { 
            disable.SetActive(false);
            enable.SetActive(true);
            fart = true;
            disableplayer.GetComponentInChildren<walk>().enabled = false;
            disableplayer.SetActive(false);
        }
}
