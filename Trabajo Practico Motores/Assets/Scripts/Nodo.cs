using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Nodo : MonoBehaviour
{
    public Color colorSecundario;
    private Renderer render;
    private GameObject torreta;
    private Color colorInicial;
    public Vector3 posicionReal;
    public bool permiteCrear;
    public static int monedasARestar;

    private void Start()
    {
        render = GetComponent<Renderer>();
        colorInicial = render.material.color;
        permiteCrear = false;
    }

    void OnMouseEnter()
    {
        render.material.color = colorSecundario;
    }
    private void OnMouseExit()
    {
        render.material.color = colorInicial;
    }

    private void OnMouseDown()
    {
        if (torreta != null)
        {
           Debug.Log("No puede construir ahí papanatas");
           return;
        }
       

        GameObject torretaAConstruir = CreadorTorretas.instance.ConseguirTorreta();
        torreta = (GameObject)Instantiate(torretaAConstruir, transform.position + posicionReal, transform.rotation);
        GameManager.monedas = GameManager.monedas - monedasARestar;
    }

    public void CambiaBool()
    {
        permiteCrear = true;
    }
}
