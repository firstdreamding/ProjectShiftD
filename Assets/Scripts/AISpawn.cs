using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AISpawn : MonoBehaviour
{
    public GameObject[] enemytoSpawn;
    public float spawnTimer;
    private Vector3 spawnCoords;
    // Start is called before the first frame update
    void Start()
    {
        
        InvokeRepeating ("Spawn", spawnTimer, spawnTimer);
        
    }
    void Spawn(){
        
        //  spawnCoords.x = Random.Range (-17, 17);
        //  spawnCoords.y = 0.5f;
        //  spawnCoords.z = Random.Range (-17, 17);
        spawnCoords = transform.position;
        spawnCoords.y += 10;
        // spawnCoords.x = spawnZone.Transform().position.x;
        // spawnCoords.y = spawnZone.Transform().position.y;
        // spawnCoords.z = spawnZone.Transform().position.z;

 
         Instantiate(enemytoSpawn[UnityEngine.Random.Range(0, enemytoSpawn.Length - 1)], spawnCoords, Quaternion.identity);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
