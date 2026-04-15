using UnityEngine;

public class movecamera : MonoBehaviour
{
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        // zoom into eye and rotation
        if (Input.GetKey(KeyCode.F))
        {
            transform.rotation=GameObject.FindWithTag("Player").transform.rotation;
            transform.position=new Vector3(GameObject.FindWithTag("Player").transform.position.x,transform.position.y,GameObject.FindWithTag("Player").transform.position.z);
        }
        // move camera
        if (Input.GetKey(KeyCode.W) || Input.GetKey(KeyCode.UpArrow))
        {
            transform.position+=transform.rotation*Vector3.forward/2f;
        }
           if (Input.GetKey(KeyCode.S) || Input.GetKey(KeyCode.DownArrow))
        {
            transform.position+=transform.rotation*Vector3.back/2f;
        }
// turn camera left and right
        if (Input.GetKey(KeyCode.A) || Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0f,-2f,0);
        }
           if (Input.GetKey(KeyCode.D) || Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0,2f,0);
        }
    }
}
