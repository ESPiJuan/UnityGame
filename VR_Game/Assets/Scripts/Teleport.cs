using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Teleport : MonoBehaviour
{
    public GameObject Player;
   
    public void teleport()
    {
        Player.transform.position = new Vector3(transform.position.x - 3f, transform.position.y +1.5f, transform.position.z);
    }
  
}
