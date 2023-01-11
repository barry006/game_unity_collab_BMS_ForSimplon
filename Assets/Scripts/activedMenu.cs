using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class activedMenu : MonoBehaviour
{
    [SerializeField] GameObject menu;
    bool b = false;


    private void Update()
    {

        if (Input.GetKeyDown("escape"))
        {
            b = !b;
            if (b)
            {
                menu.SetActive(true);
            }
            else
            {
                menu.SetActive(false);
            }
        }




       

    }

}
