using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float minSpawnInterval;
    public float maxSpawnInterval;
    private FlappyBirdController controllersrc;

    void Start()
    {
        controllersrc= FindObjectOfType<FlappyBirdController>();
        
    }
    private void FixedUpdate()
    {
        if (controllersrc.isSpeedy==false)
        {
            Invoke("SpawnPrefab", Random.Range(minSpawnInterval, maxSpawnInterval));
            prefabToSpawn.SetActive(true);
        }
        else if (controllersrc.isSpeedy == true)
        {
            CancelInvoke("SpawnPrefab");
            prefabToSpawn.SetActive(false);
        }
        
    }



    void SpawnPrefab()
    {
        // Prefab'�n spawn edilece�i pozisyonu belirle
        Vector3 spawnPosition = new Vector3(0f, Random.Range(-2f, 2f), Random.Range(-0f, 0f));

        // Prefab'� spawn et


        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);


        // Bir sonraki spawn zaman�n� rastgele belirle ve Invoke metodunu kullanarak tekrar �a��r
        float nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);
        //Invoke("SpawnPrefab", nextSpawnTime);
    }
}