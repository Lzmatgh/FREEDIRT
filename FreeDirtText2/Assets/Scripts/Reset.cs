using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reset : MonoBehaviour
{
    public GameObject ball;
    void OnTriggerEnter(Collider col) 
    {
        ball.GetComponent<Rigidbody>().velocity = new Vector3(0,0,0);
        ball.transform.position = new Vector3(0, 10, 0);
    }
}
