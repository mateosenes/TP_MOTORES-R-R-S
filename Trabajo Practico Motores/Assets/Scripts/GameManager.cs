using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject enemy1;
    public Transform Spawner;

    public float timeBetweenWave;  //Tiempo de espera entre cada wave
    private float countDown;        //Tiempo de espera antes de crear la primera wave

    private int waveNumber;


    void Start()
    {
        timeBetweenWave = 5f;
        countDown = 2f;
        waveNumber = 1;
    }

    void Update()
    {   
        //Llamamos la funcion de spawn weva cuando el timer llega a 0
        if (countDown <= 0f) 
        {
            StartCoroutine (SpawnWave());
            countDown = timeBetweenWave;
        }

        countDown -= Time.deltaTime;
    }

    IEnumerator SpawnWave() 
    {
        for (int i = 0; i < waveNumber; i++)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(1f);
        }                 
        waveNumber++;
    }

    //Spawneamos a los enemigos
    void SpawnEnemy() 
    {
        Instantiate(enemy1, Spawner.position, Spawner.rotation);
    }
}
