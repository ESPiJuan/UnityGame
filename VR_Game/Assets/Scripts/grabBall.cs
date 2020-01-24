using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class grabBall : MonoBehaviour
{
    
    public GameObject ball;
    public GameObject Hand;
    public GameObject player;
   
    
    Collider ballCol;
    Rigidbody ballRb;
    
    
    // Start is called before the first frame update
    void Start()
    {
        ballCol = ball.GetComponent<SphereCollider>();
        ballRb = ball.GetComponent<Rigidbody>();
        
    }
    Vector3 move = new Vector3(0.01f, -0.55f, 1f);
    // Update is called once per frame
    void Update()
    {
        
    }

    public void grab()
    {
        ball.transform.SetParent(Hand.transform);
        ball.transform.localPosition = move;
        player.transform.gameObject.GetComponent<Gaze>().GVROff();
        

    }
    public void throwBall(float power)
    {
        ballCol.isTrigger = false;
        ballRb.useGravity = true;
        ball.transform.SetParent(null);
        ballRb.AddForce(Hand.transform.forward * power);
    }
}
