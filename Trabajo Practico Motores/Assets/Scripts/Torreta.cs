using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torreta : MonoBehaviour
{
    private Transform objetivo;
    public float rangoDisparo = 15f;
    public string tagEnemigo = "Enemigo";
    public Transform torreta;
    public float velocidadGiro = 10f;
    public float cadenciaDisparo = 1f;
    private float tiempoCalentamiento = 0f;
    public GameObject bala;
    public Transform puntoDisparo;
    
    void Start()
    {
        InvokeRepeating("EnemigoActual", 0f, 0.5f);
    }

   
    void Update()
    {
        if (objetivo == null)
        {
            //Destroy(bala);
            return;
        }
       
        Vector3 dir = objetivo.transform.position - transform.position;
        Quaternion rot = Quaternion.LookRotation(dir);
        Vector3 rotacion =Quaternion.Lerp(torreta.rotation,rot,Time.deltaTime*velocidadGiro).eulerAngles;
        torreta.rotation = Quaternion.Euler(0f,rotacion.y,0f);
       
        if (tiempoCalentamiento <= 0f)
        {
            Disparar();
            tiempoCalentamiento = 1f / cadenciaDisparo;
        }
        tiempoCalentamiento -= Time.deltaTime;

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

   

    void Disparar()
    {
        //Debug.Log("DISPARO");
        GameObject balaDisp=(GameObject) Instantiate(bala, puntoDisparo.position, puntoDisparo.rotation);
        balaDisp.tag = "BalaTorreta1";
        Bala disparo = balaDisp.GetComponent<Bala>();
        
        if(bala!= null)
        {
            disparo.Perseguir(objetivo);
        }
    }
}
