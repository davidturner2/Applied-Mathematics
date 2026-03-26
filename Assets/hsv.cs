using TMPro;
using Unity.Mathematics;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class hsv : MonoBehaviour
{
    public TextMeshProUGUI txt;
    public TextMeshProUGUI txt2;
    public TextMeshProUGUI txt3;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 m = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x,Input.mousePosition.y,10f));
       
        float theta = Mathf.Atan2(m.y,m.x);
        if (theta < 0)
        {
            theta+=2*Mathf.PI;
        }
        float angle = theta*Mathf.Rad2Deg;
        float r = Vector2.Distance(Vector2.zero, new Vector2(Mathf.Clamp(m.x,-10f,10f),Mathf.Clamp(m.y,-5f,5f)));
        txt.text = ""+r;
        txt2.transform.position = Input.mousePosition;
        txt2.text = "Angle: "+angle;
        Camera.main.backgroundColor=Color.HSVToRGB(angle/360f,r/10f,1);
    }
}
