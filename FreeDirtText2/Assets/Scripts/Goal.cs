using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Goal : MonoBehaviour
{
    public GameObject ball;
    Material objectMaterial;
    void Start()
    {
        objectMaterial = ball.GetComponent<Renderer>().material;
    }
    
    void OnTriggerEnter(Collider col)
    {
        if(gameObject.name == "RedGoal"){
           objectMaterial.color = Color.red; 
           
        }
        
        else if(gameObject.name == "BlueGoal"){
            objectMaterial.color = Color.blue;
        }
    }
}
