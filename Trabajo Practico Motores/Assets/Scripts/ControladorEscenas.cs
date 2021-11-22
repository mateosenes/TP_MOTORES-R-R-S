using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ControladorEscenas : MonoBehaviour
{
    public GameObject pantallaSalir;
    
    public void ComienzoJuego()
    {
        SceneManager.LoadScene("Escenario de Juego", LoadSceneMode.Single);
    }

    public void MenuInicio() 
    {
        SceneManager.LoadScene("Menú", LoadSceneMode.Single);
        pantallaSalir.SetActive(false);
    }

    public void RevelarSalir()
    {
        pantallaSalir.SetActive(true);
    }

    public void CerrarJuego()
    {
        Application.Quit();
    }

    public void VolveralMenu()
    {
        pantallaSalir.SetActive(false);
    }
}
