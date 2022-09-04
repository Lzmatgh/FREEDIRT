using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SeedManager : MonoBehaviour 
{
    public GameObject seedOriginal;
    public Transform spawnPoint;
    private Vector3 spawnCoord;
    public List<GameObject> seeds = new List<GameObject>();

    void Start()
    {
        spawnCoord = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
    }

    void Update()
    {
        if(Input.GetKeyDown("space")) {
            CreateSeed();
        }
    }

    public void CreateSeed()
    {
        spawnCoord = new Vector3(spawnPoint.position.x, spawnPoint.position.y, spawnPoint.position.z);
        GameObject newSeed = Object.Instantiate(seedOriginal, spawnCoord, Quaternion.identity);
        seeds.Add(newSeed);
        Debug.Log("Spawn seed on key press.");
    }

    void SetSeedMaterial()
    {

    }

    void MakeInteractable()
    {

    }
}
