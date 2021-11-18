using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VIdaEnemigo : MonoBehaviour
{
    public int vidaEnemigo;

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
        Destroy(gameObject);
        GameManager.monedas += 20;
        GeneradorOleada.enemigosVivos--;
    }


}
