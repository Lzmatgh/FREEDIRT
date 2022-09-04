using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MakeSeed : MonoBehaviour 
{
    public GameObject seedOriginal;
    public Transform spawnPoint;
    private List<GameObject> seeds = new List<GameObject>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetKeyDown("space")) {
            GameObject newSeed = Object.Instantiate(seedOriginal, spawnPoint);
            seeds.Add(newSeed);
            Debug.Log("Spawn seed on key press.");
        }
    }

    void CreateSeed()
    {
        Object.Instantiate(seedOriginal, spawnPoint);
    }

    void SetSeedMaterial()
    {

    }

    void MakeInteractable()
    {

    }
}
