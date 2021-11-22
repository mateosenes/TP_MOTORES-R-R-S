using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public float speed;
    GameObject wayPoint;
    public GameObject efectoDestruccion1;

    // Start is called before the first frame update
    void Start()
    {
        wayPoint = GameObject.Find("Waypoint ");
        //wayPoint = wayPoint.GetComponent<Waypoints>().GetNext(this.gameObject);
    }

    // Update is called once per frame
    void Update()
    {
        if (transform.position != wayPoint.transform.position)
        {
            transform.position = Vector3.MoveTowards(transform.position, wayPoint.transform.position, speed * Time.deltaTime);
        }
        else 
        {
            wayPoint = wayPoint.GetComponent<Waypoints>().GetNext(this.gameObject);
        }
    }
    void OnCollisionEnter(Collision other)
    {
        Debug.Log("colisiono");
        if (other.gameObject.CompareTag("End"))
        {
            LLegaBaseAliada();
        }
    }

    void LLegaBaseAliada()
    {
        GameManager.vidas-=10;
        GameObject.FindObjectOfType<GameManager>().HacerDaño();
        GeneradorOleada.enemigosVivos--;
        Debug.Log(GameManager.vidas);
        GameObject instEfect1 = (GameObject)Instantiate(efectoDestruccion1, transform.position, transform.rotation);
        Destroy(instEfect1, 2f);
        Destroy(gameObject);
    }
}
