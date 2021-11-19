using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bala : MonoBehaviour
{
    private Transform objetivo;
    public float velocidadDisparo=10f;
    public int dañoDeBala;

    public float tiempoMax;
    private float tiempo;

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

        if (this.gameObject.activeSelf)
        {
            tiempo += Time.deltaTime;
            if (tiempo >= tiempoMax)
            {
                Desactivar();
            }
        }
    }
    
    public void Perseguir(Transform _objetivo)
    {
        objetivo = _objetivo;
    }
   
    public void GolpearObjetivo()
    {
        GameObject.FindObjectOfType<VIdaEnemigo>().RecibirDaño(dañoDeBala);
        Destroy(gameObject);
    }

    void Desactivar()
    {
        tiempo = 0;
        this.gameObject.SetActive(false);
    }
}
