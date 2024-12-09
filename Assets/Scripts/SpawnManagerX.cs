using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnManagerX : MonoBehaviour
{
    public GameObject[] FoodPrefabs; 
    private float startDelay = 2;
    private float spawnInterval = 2;
    private float spawnPosZ = 20;
    private float spawnRangeX = 20;
    // Start is called before the first frame update
    void Start()
    {
     InvokeRepeating("SpawnRandomFood", startDelay, spawnInterval);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

        void SpawnRandomFood()
    {
        // Randomy generate animal index and spawn position
            Vector3 spawnPos = new Vector3(Random.Range(-spawnRangeX, spawnRangeX), 0.5f, Random.Range(-spawnPosZ, spawnPosZ));
        int FoodIndex = Random.Range(0, FoodPrefabs.Length);
        Instantiate(FoodPrefabs[FoodIndex], spawnPos, FoodPrefabs[FoodIndex].transform.rotation);
    }

    

}
