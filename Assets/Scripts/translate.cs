using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class translate : MonoBehaviour
{
   
    [SerializeField] private float speed;    
     private Vector3 v3;
    [SerializeField] private float distanceAvansDestroy = 100f;
    
    void Start()
    {
        v3 = gameObject.transform.position;  
    }

  
    void Update()
    {
     
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        // if distance v3 > distanceAvansDestroy destroy gameObject;
        if (Vector3.Distance(v3, transform.position)> distanceAvansDestroy)
        {             
                Destroy(gameObject);
        }
       
    }
   
}
