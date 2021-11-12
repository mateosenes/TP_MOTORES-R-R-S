using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private Transform objetivo;
    public float velocidadDisparo=10f;
    void Update()
    {
        if (objetivo == null)
        {
            Destroy(gameObject);
            return;
        }
        Vector3 dir = objetivo.position - transform.position;
        float distancia = velocidadDisparo * Time.deltaTime;
        if (dir.magnitude <= distancia)
        {
            GolpearObjetivo();
            return;
        }
        transform.Translate(dir.normalized * distancia, Space.World);
    }
    public void Perseguir(Transform _objetivo)
    {
        objetivo = _objetivo;
    }
    public void GolpearObjetivo()
    {
        Destroy(gameObject);
    }
}
