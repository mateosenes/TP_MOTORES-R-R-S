using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreadorTorretas : MonoBehaviour
{
    public static CreadorTorretas instance;
    private GameObject torretaAConstruir;
    public GameObject torretaStandard;
    private void Start()
    {
        torretaAConstruir = torretaStandard;
    }
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
}
