using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement; //NameSpace for use SceneManagement.

public class sceneSuivante : MonoBehaviour
{
    [SerializeField] string loadScene=""; //string for write name of scene.



    public void NextScene() //Methode for change scene.
    {
        SceneManager.LoadScene(loadScene); //Load scene name with string "loadScene".
    }


    private void OnTriggerEnter(Collider other) //Trigger for change scene if player collider with trigger.
    {
        if (other.gameObject.CompareTag("Player"))
        {
            NextScene();
        }
    }
}
