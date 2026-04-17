using UnityEngine;

public class localtoworld : MonoBehaviour
{
    public GameObject hello;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        print(hello.transform.position.y);
        transform.position=hello.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
