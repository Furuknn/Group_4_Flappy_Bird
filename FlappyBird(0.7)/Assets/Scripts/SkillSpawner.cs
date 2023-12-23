using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SkillSpawner : MonoBehaviour
{
    public GameObject prefabToSpawn;
    public float minSpawnInterval = 1f;
    public float maxSpawnInterval = 5f;

    void Start()
    {
        // �lk spawn i�lemi i�in Invoke metodunu kullanabiliriz.
        Invoke("SpawnPrefab", Random.Range(minSpawnInterval, maxSpawnInterval));
    }

    void SpawnPrefab()
    {

        // Prefab'�n spawn edilece�i pozisyonu belirle
        Vector3 spawnPosition = new Vector3(16, 0f, Random.Range(-0f, 0f));

        // Prefab'� spawn et
        Instantiate(prefabToSpawn, spawnPosition, Quaternion.identity);

        // Bir sonraki spawn zaman�n� rastgele belirle ve Invoke metodunu kullanarak tekrar �a��r
        float nextSpawnTime = Random.Range(minSpawnInterval, maxSpawnInterval);
        Invoke("SpawnPrefab", nextSpawnTime);
    }
}