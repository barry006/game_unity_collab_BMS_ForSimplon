using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translatePing2 : MonoBehaviour
{
    public float speed;
    public GameObject[] waypoints;
    int cwi = 0;

    void Update()
    {
        if (Vector3.Distance(transform.position, waypoints[cwi].transform.position) < .1f)
        {
            cwi++;
            if (cwi >= waypoints.Length)
            {
                cwi = 0;
            }
        }
        transform.position = Vector3.MoveTowards(transform.position, waypoints[cwi].transform.position, speed * Time.deltaTime);
    }
}