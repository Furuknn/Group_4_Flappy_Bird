using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSpawn : MonoBehaviour
{
    public GameObject objectToSpawn;
    public float yukseklik;
    public float minSpawnTime = 1f;
    public float maxSpawnTime = 5f;
    
    private void Start()
    {
        InvokeRepeating("SpawnObject", 10f, Random.Range(minSpawnTime, maxSpawnTime));

    }

    private void SpawnObject()
    {
        GameObject speedskill = Instantiate(objectToSpawn);
        speedskill.transform.position = transform.position + new Vector3(15, Random.Range(-yukseklik, yukseklik), 0);

        Destroy(speedskill,15);
    }
}

