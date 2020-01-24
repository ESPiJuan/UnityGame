using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BoatCollis : MonoBehaviour
{
    
    public GameObject player;
    Scene m_Scene;
    string sceneName;
    bool boat1, boat2, boat3 ;
    void Start()
    {
        m_Scene = SceneManager.GetActiveScene();
        sceneName = m_Scene.name;
        boat1 = false;
        boat2 = false;
    
    boat3 = false;
    }

    // Update is called once per frame
    void Update()
    {

       

    }

    void OnCollisionEnter(Collision collision)
    {

        if (transform.gameObject.CompareTag("Boat")&&!boat1)
        {
            boat1 = true;
            
 
            
            Destroy(transform.gameObject);
          
            
            Destroy(collision.gameObject);
            player.transform.gameObject.GetComponent<Gaze>().GVROff();

            if (sceneName == "02")
            {
                player.GetComponent<Gaze>().incrementPoints(25);
            }
            else
            {
                player.GetComponent<Gaze>().incrementPoints(50);
            }
            player.GetComponent<Gaze>().incrementWin(1);

        }
        if (transform.gameObject.CompareTag("Boat2") && !boat2)
        {
           
            boat2 = true;
            
            
            Destroy(transform.gameObject);
            
            Destroy(collision.gameObject);
            player.transform.gameObject.GetComponent<Gaze>().GVROff();
            if (sceneName == "02")
            {
                player.GetComponent<Gaze>().incrementPoints(50);
            }
            else
            {
                player.GetComponent<Gaze>().incrementPoints(75);
            }
            
            player.GetComponent<Gaze>().incrementWin(1);

        }
        if (transform.gameObject.CompareTag("Boat3") && !boat3)
        {
           
            boat3 = true;
            
            
            Destroy(transform.gameObject);
            
            Destroy(collision.gameObject);
            player.transform.gameObject.GetComponent<Gaze>().GVROff();

            if (sceneName == "02")
            {
                player.GetComponent<Gaze>().incrementPoints(25);
            }
            else
            {
                player.GetComponent<Gaze>().incrementPoints(50);
            }
            player.GetComponent<Gaze>().incrementWin(1);

        }
        if (transform.gameObject.CompareTag("Water"))
        {
            
            Destroy(collision.gameObject);
            player.transform.gameObject.GetComponent<Gaze>().GVROff();
            player.GetComponent<Gaze>().incrementWin(1);
        }



    }
}
