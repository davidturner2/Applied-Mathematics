using UnityEngine;

public class worldtolocal : MonoBehaviour
{
    public Transform blue;
    public Transform green;
    public Transform localspace;

    

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

void worltolocal() 
{
    // setting the transform of the world object to project to the local point     
    blue.transform.up=Vector3.Dot(Vector3.up,localspace.transform.up)*localspace.transform.up;
    blue.transform.right=Vector3.Dot(Vector3.right,localspace.transform.right)*localspace.transform.right;
    blue.transform.forward=Vector3.Dot(Vector3.forward,localspace.transform.forward)*localspace.transform.forward;
    
      // setting the position of the world object by projecting with the basis of the localspace
     Vector3 offset=(green.localPosition.x*localspace.transform.right+green.localPosition.y*localspace.transform.up+green.localPosition.z*localspace.transform.forward);

    blue.position = localspace.position+offset;
}


    void localtoworld()
    {
    
        // setting the transform of the local object to project to the world point
        green.transform.up=Vector3.Dot(localspace.transform.up,Vector3.up)*Vector3.up;
        green.transform.right=Vector3.Dot(localspace.transform.right,Vector3.right)*Vector3.right;
        green.transform.forward=Vector3.Dot(localspace.transform.forward,Vector3.forward)*Vector3.forward;



        // setting the position of the local object to project to the world point using the blue position to localspace basis tranforms
        Vector3 bdis = blue.position-localspace.position;         
        green.localPosition = new Vector3(Vector3.Dot(localspace.transform.right,bdis),Vector3.Dot(localspace.transform.up, bdis),Vector3.Dot(localspace.transform.forward,bdis));
    }

  
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.K))
        {
            worltolocal();
        }
        else if (Input.GetKeyDown(KeyCode.J))
        {
            localtoworld();
        }
                

    }
}
