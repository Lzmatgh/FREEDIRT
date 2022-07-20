using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //SceneManager.LoadScene(0);
        print("should be loading scene");
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape)){
            SceneManager.LoadScene(0);
        }
    }

    public void loadScene(int sceneIndex) 
    {
        SceneManager.LoadScene(sceneIndex);
        print("should be loading scene: " + sceneIndex);
    }
}
