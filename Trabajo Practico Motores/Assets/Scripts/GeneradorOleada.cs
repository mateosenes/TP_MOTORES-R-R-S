using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GeneradorOleada : MonoBehaviour
{
    public static int enemigosVivos;

    public Oleada[] oleadas; 
    public Transform coordenadasGenerador;

    public float tiempoEntreRondas;
    private float contador;

    public Text textoContadorOleadas;

    private int numeroOleada;

    private void Start()
    {
        numeroOleada = 0;
        enemigosVivos = 0;
    }

    private void Update()
    {
        if (enemigosVivos > 0)
        {
            return;
        }

        if (contador <= 0f) 
        {
            StartCoroutine(GenerarOleada());
            contador = tiempoEntreRondas;
            return;
        }

        contador -= Time.deltaTime;

        textoContadorOleadas.text = Mathf.Round(contador).ToString();
    }

    IEnumerator GenerarOleada()
    {
        Oleada oleada = oleadas[numeroOleada];

        for (int i = 0; i < oleada.cantidadEnemigos; i++)
        {
            GenerarEnemigo(oleada.prefabEnemigo);
            yield return new WaitForSeconds(1f / oleada.promedio);
        }

        Debug.Log("Orda en camino!");
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
