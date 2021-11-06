using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    float speed;
    GameObject wayPoint;

    // Start is called before the first frame update
    void Start()
    {
        speed = 10f;
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

    void OnCollisionEnter (Collision other)
    {
        Debug.Log("colisiono");
        if (other.gameObject.CompareTag("End")) 
        {
            Destroy(gameObject);
        }
    }
}
