using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class spawner2 : MonoBehaviour
{
    public GameObject cube;
    public GameObject cube2;
    Vector2 xinterval = new Vector2(-9, 6);
    public List<Transform> cubes;
    public List<Transform> cubes2;
    public float step = 0.003f;
    public float a, b, c, d, e, f, g;
    float steppers = 0f;



    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {        
        for (float i = xinterval.x; i < xinterval.y; i += step)
        {
            GameObject hi = Instantiate(cube);
            hi.transform.parent = transform;
            cubes.Add(hi.transform);
            GameObject hi2 = Instantiate(cube2);
            hi2.transform.parent = transform;
            cubes2.Add(hi2.transform);
            //
            //Debug.Log(map(i,-15,15,-5,10)+"Mapping from -5 to 10");
        }
    }

    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < cubes.Count; i++)
        {
            float x = i * step + xinterval.x;
            float y = 1 - ((1f) / (60f))*x*(x + 4)*(x - 6);
            cubes[i].localPosition = new Vector3(x, y, 0);
        }
        for (int i = 0; i < cubes2.Count; i++)
        {
            float x = i * step + xinterval.x;
            float y = 1 - ((1f) / (60f)) * x * (x + 4) * (x - 6);
            cubes2[i].localPosition = new Vector3(x, y, 2f*math.sin(x*3));
        }
    }
}
