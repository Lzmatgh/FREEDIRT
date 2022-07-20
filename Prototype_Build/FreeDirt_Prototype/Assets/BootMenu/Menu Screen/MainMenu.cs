using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // public bool isStart;
    // public bool isQuit;
    // public bool isCredit;
    // public bool isControl;
    public bool isStart = false;
    public bool isQuit = false;
    public bool isCredit = false;
    public bool isControl = false;
    // public GameObject MainMenu;
    // public GameObject CreditMenu;
    // public GameObject PlayGame;

    // Start is called before the first frame update
    void Start()
    {
        //UnityEngine.SceneManagement.SceneManager.LoadScene(0);
        //MainMenu.SetActive(true);
        //CreditMenu.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void OnMouseUp() {
        if(isStart) {
            print("pls start for gods sake");
            UnityEngine.SceneManagement.SceneManager.LoadScene(1);
        }

        if(isQuit) {
            Application.Quit();
        }

        if(isCredit) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(2);
        }

        if(isControl) {
            UnityEngine.SceneManagement.SceneManager.LoadScene(3);
        }
    }
}
