using Unity.Mathematics;
using UnityEngine;

public class rotater : MonoBehaviour
{
    Transform[] keys;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        keys = new Transform[transform.childCount];
        for (int i = 0; i < transform.childCount; i++)
        {
            keys[i] = transform.GetChild(i);
        }
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].rotation = Quaternion.Euler(new Vector3(0,90,-7f *math.abs(math.pow(math.cos(1f*Time.time+i+(1*0.01f *math.PI)),20))));
        }
    }
}
