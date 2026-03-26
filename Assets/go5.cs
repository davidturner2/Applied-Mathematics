using UnityEngine;

public class go5 : MonoBehaviour
{
   //  public GameObject cube2;
    Vector2 xinterval = new Vector2(0, 6.288f);
    //public List<Transform> cubes;
    // public List<Transform> cubes2;
    public float step = 0.003f;
    float steppers = 0f;
    float r;
    Vector3 r2;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        r = UnityEngine.Random.Range(100f, 200f);
        if (UnityEngine.Random.Range(0f, 50f) < 25f)
        {
            r *= -1;
        }
        r2 = new Vector3(UnityEngine.Random.Range(0, 2), UnityEngine.Random.Range(0, 2), UnityEngine.Random.Range(1, 2));

      // square knot credit to https://mathcurve.com/courbes3d.gb/plat.vache/plat_vache.shtml
        float t = 1f/10f*(xinterval.x + steppers);
        transform.localPosition = new Vector3(3f*Mathf.Sin(t)+2*Mathf.Sin(3*t), Mathf.Cos(5*t), Mathf.Cos(t)-2*Mathf.Cos(3*t));

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(r2 * r * Time.deltaTime);
        steppers += 100 * Time.deltaTime / 41.009f;
        float t = 1f/10f*(xinterval.x + steppers);


        GetComponent<MeshRenderer>().material.color = new Vector4(map(t,0,6.29f,0,1),1,0,1);
        GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", new Vector4(map(t, 0, 6.29f, 0, 2), 0, 1, 1));



        // square knot credit to https://mathcurve.com/courbes3d.gb/plat.vache/plat_vache.shtml
        transform.localPosition = new Vector3(3f*Mathf.Sin(t)+2*Mathf.Sin(3*t), Mathf.Cos(5*t), Mathf.Cos(t)-2*Mathf.Cos(3*t));

        if (t > xinterval.y)
        {
            Destroy(gameObject);
        }

    }


    float map(float val, float o1,float o2, float n1, float n2)
    {
        // recreated the map function from processing by converting the old values into 0 to 1 using the old min and max and using a lerp fuction to map it the new min and max
        return Mathf.Lerp(n1,n2,(val-o1)/o2);
    }
}
