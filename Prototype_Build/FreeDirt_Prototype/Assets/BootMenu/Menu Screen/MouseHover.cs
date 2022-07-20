using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;

public class MouseHover : MonoBehaviour
{
    //Color black = new Color(0,0,0,0);
    //Color white = new Color(255,255,255, 1);
    
    // Start is called before the first frame update
    //bool pauseToggle;

    void Start()
    {
        //text.color = black;
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnMouseEnter() {
        GetComponent<Text>().color = Color.white;
        //text.color = white;
    }

    void OnMouseExit() {
        GetComponent<Text>().color = Color.black;
        //text.color = black;
    }
}
