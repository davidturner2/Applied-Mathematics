using UnityEngine;

public class go4 : MonoBehaviour
{
   //  public GameObject cube2;
    Vector2 xinterval = new Vector2(0, 6.28f);
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

        float t = 1f/10f*(xinterval.x + steppers);
        transform.localPosition = new Vector3(5f*Mathf.Pow(Mathf.Cos(t*5)*Mathf.Sin(t*5),2), 5*Mathf.Sin(t)*Mathf.Cos(t), 5f * Mathf.Sin(t));

    }

    // Update is called once per frame
    void FixedUpdate()
    {
        transform.Rotate(r2 * r * Time.deltaTime);
        steppers += 100 * Time.deltaTime / 41.009f;





        float t = 1f/10f*(xinterval.x + steppers);
        //float y = xinterval.x + steppers;
        //float z = (10f/20f)*steppers;
        transform.localPosition = new Vector3(5f*Mathf.Pow(Mathf.Cos(t*5)*Mathf.Sin(t*5),2), 5*Mathf.Sin(t)*Mathf.Cos(t), 5f * Mathf.Sin(t));

        if (t > xinterval.y)
        {
            Destroy(gameObject);
        }

    }
}
