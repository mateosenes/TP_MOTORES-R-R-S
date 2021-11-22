using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIdaEnemigo : MonoBehaviour
{
    public int vidaEnemigo;
    public GameObject efectoDestruccion;

    public AudioClip sonidoExploci�n;

    AudioSource audioSource;

    public void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    public void RecibirDa�o(int i) 
    {
        vidaEnemigo -= i;
        if (vidaEnemigo <= 0) 
        {
            Morir();
            audioSource.PlayOneShot(sonidoExploci�n);
        }
    }

    private void Morir() 
    {
        GameObject instEfect = (GameObject)Instantiate(efectoDestruccion, transform.position, transform.rotation);
        Destroy(instEfect, 2f);
        Destroy(gameObject);
        GameManager.monedas += 20;
        GeneradorOleada.enemigosVivos--;
    }


}
