using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    private Transform objetivo;
    public float rangoDisparo = 15f;
    public string tagEnemigo = "Enemigo";
    public Transform torreta;
    
    void Start()
    {
        InvokeRepeating("EnemigoActual", 0f, 0.5f);
    }

   
    void Update()
    {
        if (objetivo == null)
        {
            return;
        }
        Vector3 dir = objetivo.transform.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(dir);
        Vector3 rotacion = rot.eulerAngles;
        torreta.rotation = Quaternion.Euler(0f,rotacion.y,0f);

    }
    void EnemigoActual()
    {
        GameObject[] enemigos = GameObject.FindGameObjectsWithTag(tagEnemigo);
        float distanciaCorta = Mathf.Infinity;
        GameObject enemigoCerca = null;
        foreach(GameObject Enemigo in enemigos)
        {
            float distanciaEnemigo = Vector3.Distance(transform.position, Enemigo.transform.position);
            if (distanciaEnemigo<distanciaCorta)
            {
                distanciaCorta = distanciaEnemigo;
                enemigoCerca = Enemigo;
            }
        }
        if(enemigoCerca!=null && distanciaCorta <= rangoDisparo)
        {
            objetivo = enemigoCerca.transform;
        }
        else
        {
            objetivo = null;
        }
    }
}
