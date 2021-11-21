using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControladorCamara : MonoBehaviour
{

    private float vertical;
    private float horizontal;
    private float velocidad;
    private float bordePantalla;
    private float ruedita;
    private float velocidadRuedita;
    public float minY;
    public float maxY;

    private void Start()
    {
        velocidad = 20f;
        bordePantalla = 10f;
        velocidadRuedita = 5f;
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

        ruedita = Input.GetAxis("Mouse ScrollWheel");

        Vector3 posicion = transform.position;

        posicion.y -= ruedita * 1000 * velocidadRuedita * Time.deltaTime;
        posicion.y = Mathf.Clamp(posicion.y, minY, maxY);

        transform.position = posicion;
    }
}
