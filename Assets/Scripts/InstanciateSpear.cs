using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstanciateSpear : MonoBehaviour
{
      
    public GameObject prefab;
    public float commence;
    public float touteLes;
 
    void Start()
    {
        InvokeRepeating("LaunchProjectile", commence, touteLes);
    }

    void LaunchProjectile()
    {
        Instantiate(prefab, gameObject.transform.position, Quaternion.identity);
    }







}
