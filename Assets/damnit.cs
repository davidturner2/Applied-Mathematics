using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class damnit : MonoBehaviour
{
    public float sensitivity;
    public float rotationSpeed = 200.029382f;
    public Camera mainCamera;
    public GameObject player;
    private Racer trolls;
    private Vector2 camPos = Vector2.zero;
    Vector3 ghjkl;
    float accel = 100f;
    bool computer = true;
    bool curve = true;
    // Start is called before the first frame update
    public void Awake()
    {
        trolls = new Racer();

        trolls.PCtrolls.camera.performed += ctx => p(ctx.ReadValue<Vector2>());
        trolls.PCtrolls.camera.canceled += ctx => pa();



    }
    private void OnEnable()
    {
        trolls.PCtrolls.Enable();
    }
    private void OnDisable()
    {
        trolls.PCtrolls.Disable();
    }
    void Start()
    {
        ghjkl = transform.position;
    }
    void p(Vector2 e)
    {
        camPos = e;
        computer = false;
    }
    void pa()
    {
        camPos = Vector2.zero;
        computer = true;

    }
    // Update is called once per frame
    void FixedUpdate()
    {
                transform.position = player.transform.position+ ghjkl;
      
        //transform.RotateAround( player.transform.position-new Vector3(0,0,-5),Vector3.up , 10 * rotationSpeed * Time.deltaTime*MathF.Sin(Time.deltaTime));


    }
}




// Update is called once per frame
