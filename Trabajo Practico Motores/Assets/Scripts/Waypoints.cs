using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoints : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject nextCheckPoint;

    public GameObject GetNext(GameObject enemy)
    {
        GameObject next;

        next = nextCheckPoint;

        return next;
    }
}
