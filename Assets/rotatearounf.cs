using UnityEngine;

public class rotatearounf : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        if (Input.GetKey(KeyCode.T))
        {
            transform.Rotate(Vector3.up);
        }
    }
}
