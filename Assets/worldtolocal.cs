using UnityEngine;

public class worldtolocal : MonoBehaviour
{
    public Transform blue;
    public Transform localspace;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

     
    void OnDrawGizmos()
    {
    Gizmos.color = Color.green;
    Gizmos.DrawRay(localspace.position, localspace.up);
    }
    void worltolocal()
    {
        print(localspace.position+localspace.up);
    }
    // Update is called once per frame
    void Update()
    {
        blue.position = localspace.position+localspace.up;
        worltolocal();
    }
}
