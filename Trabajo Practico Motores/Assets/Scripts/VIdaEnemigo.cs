using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIdaEnemigo : MonoBehaviour
{
    public int vidaEnemigo;
    public GameObject efectoDestruccion;

    public void RecibirDaño(int i) 
    {
        vidaEnemigo -= i;
        if (vidaEnemigo <= 0) 
        {
            Morir();
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
