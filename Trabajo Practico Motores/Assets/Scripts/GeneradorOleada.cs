using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneradorOleada : MonoBehaviour
{
    public static int enemigosVivos;

    public Oleada[] oleadas; 
    public Transform coordenadasGenerador;

    public float tiempoEntreOleadas;
    private float contador;

    public Text textoContadorOleada;
    public Text textoAviso;

    private int numeroOleada;

    private void Start()
    {
        numeroOleada = 0;
        enemigosVivos = 0;

        contador = 10.5f;
    }

    private void Update()
    {

        if (enemigosVivos > 0)
        {
            return;
        }

        if (contador <= 0f) 
        {
            textoAviso.text = "AHI VIENEN!!";
            textoContadorOleada.text = "";
            StartCoroutine(GenerarOleada());
            contador = tiempoEntreOleadas;
            return;
        }
        
        textoAviso.text = "";
        contador -= Time.deltaTime;
        contador = Mathf.Clamp(contador, 0f, Mathf.Infinity);
        textoContadorOleada.text = string.Format("{0:00.00}", contador);
    
    }

    IEnumerator GenerarOleada()
    {
        Oleada oleada = oleadas[numeroOleada];

        for (int i = 0; i < oleada.cantidadEnemigos; i++)
        {
            GenerarEnemigo(oleada.prefabEnemigo);
            yield return new WaitForSeconds(1f / oleada.promedio);
        }

        numeroOleada++;

        if (numeroOleada == oleadas.Length)
        {
            numeroOleada = 0;
        }
    }

    void GenerarEnemigo(GameObject prefabEnemigo)
    {
        Instantiate(prefabEnemigo, coordenadasGenerador.position, coordenadasGenerador.rotation);
        enemigosVivos++;
    }
}
