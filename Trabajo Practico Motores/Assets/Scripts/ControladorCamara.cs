using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour
{

    private float vertical;
    private float horizontal;
    private float velocidad;
    public float minZ;
    public float maxZ;

    private void Start()
    {
        velocidad = 20f;
    }

    void Update()
    {


        if (Input.GetKey("w"))
        {
            transform.Translate(Vector3.forward * velocidad * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("s"))
        {
            transform.Translate(Vector3.back * velocidad * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("a"))
        {
            transform.Translate(Vector3.left * velocidad * Time.deltaTime, Space.World);
        }
        if (Input.GetKey("d"))
        {
            transform.Translate(Vector3.right * velocidad * Time.deltaTime, Space.World);
        }
    }
}
