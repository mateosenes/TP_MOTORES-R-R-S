using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorTorretas : MonoBehaviour
{
    public static CreadorTorretas instance;
    private GameObject torretaAConstruir;
    

    private void Awake()
    {
        if (instance != null)
        {
            Debug.LogError("Más de un GameManager");
            return;
        }
        instance = this;
    }

    public GameObject ConseguirTorreta()
    {
        return torretaAConstruir;
    }

    public void ElegirTorretaAConstruir(GameObject torreta) 
    {
        torretaAConstruir = torreta;
    }
}
