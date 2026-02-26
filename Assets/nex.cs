using System;
using UnityEngine;
using UnityEngine.Assertions.Must;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class nex : MonoBehaviour
{
    public GameObject[] tfdtr;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.D))
        {
            GetComponent<RectTransform>().position += Vector3.right;
        }
        if (Input.GetKey(KeyCode.A))
        {
            GetComponent<RectTransform>().position += Vector3.left;
        }
        if (Input.GetKey(KeyCode.W))
        {
            GetComponent<RectTransform>().position += Vector3.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            GetComponent<RectTransform>().position += Vector3.down;
        }

        for (int i = 0; i < tfdtr.Length; i++)
        {
            blood(tfdtr[i]);
        }
        //print(GetComponent<RectTransform>().rect.width);
    }

    void blood(GameObject y)
    {
        RectTransform a = y.GetComponent<RectTransform>();
        float exr = (GetComponent<RectTransform>().position.x - GetComponent<RectTransform>().rect.width / 2f);
        float exr2 = (GetComponent<RectTransform>().position.y - GetComponent<RectTransform>().rect.height / 2f);
        float dxr = (a.position.x - a.rect.width / 2f);
        float dxr2 = (a.position.y - a.rect.height / 2f);


        if (((exr >= dxr || exr + GetComponent<RectTransform>().rect.width >= dxr)&&exr<dxr+a.rect.width)&& ((exr2 >= dxr2 || exr2 + GetComponent<RectTransform>().rect.height >= dxr2) && exr2 < dxr2 + a.rect.height))
        {
            y.GetComponent<RawImage>().color = Color.red;
        }
        else
        {
            y.GetComponent<RawImage>().color = Color.white;
        }
    }
}
