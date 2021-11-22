using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEditor;

public class ControladorEscenas : MonoBehaviour
{
    public GameObject pantallaSalir;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void ComienzoJuego()
    {
        SceneManager.LoadScene("Escenario de Juego", LoadSceneMode.Single);
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
