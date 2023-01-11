using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class JAIPASDIDEE : MonoBehaviour
{
    public List<GameObject> monNom;




    void Start()
    {

    }


    void Update()
    {
        foreach (var item in monNom)
        {
            item.transform.Translate(0f, 0f, 1f);
        }
        //monNom.transform.Translate(0f, 0f, 1f);
    }
}
