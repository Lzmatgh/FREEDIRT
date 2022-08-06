using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController : MonoBehaviour
{
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape)) {
            SceneManager.LoadScene("StartConfig");
        }
    }

    public void StartDirt()
    {
        SceneManager.LoadScene("Stage");
    }
}
