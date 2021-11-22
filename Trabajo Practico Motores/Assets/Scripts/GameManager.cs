using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public GameObject torreta1;
    public GameObject torreta2;
    public GameObject torreta3;

    public Text monedastxt;

    public static int monedas = 200;

    public static float vidas;
    public float vidasIniciales;
    private float vidaBarra;

    public Image vida;

    void Start()
    {
        monedastxt.text = monedas.ToString();
        vidas = vidasIniciales;
        vidaBarra = 1000f;
    }

    void Update()
    {
        monedastxt.text = monedas.ToString();

        if (vidas <= 0) 
        {
            Perder();
        }
    }

    public void ComprarTorreta1() 
    {
        if (monedas >= 10) 
        {
            GameObject.FindObjectOfType<CreadorTorretas>().ElegirTorretaAConstruir(torreta1);
            Nodo.monedasARestar = 20;
            monedastxt.text = monedas.ToString();
        }
    }

    public void ComprarTorreta2()
    {
        if (monedas >= 15)
        {
            GameObject.FindObjectOfType<CreadorTorretas>().ElegirTorretaAConstruir(torreta2);
            Nodo.monedasARestar = 40;
            monedastxt.text = monedas.ToString();
        }
    }

    public void ComprarTorreta3()
    {
        if (monedas >= 20)
        {
            GameObject.FindObjectOfType<CreadorTorretas>().ElegirTorretaAConstruir(torreta3);
            Nodo.monedasARestar = 60;
            monedastxt.text = monedas.ToString();
        }
    }

    private void Perder() 
    {
        //aca perdes y pones todo lo q tiene q salir
        Debug.Log("Game Over");
    }

    public void HacerDaño() 
    {
        vida.fillAmount -= vidas / vidaBarra;
    }
}
