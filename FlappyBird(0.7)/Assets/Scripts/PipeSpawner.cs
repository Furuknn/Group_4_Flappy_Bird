using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeSpawner : MonoBehaviour
{
    public float maxTime = 1;
    public float timer = 0;
    public GameObject pipeOrg,pipeXmas;
    private GameObject newPipe;
    public float yukseklik;
    void Start()
    {
        if (PlayerPrefs.GetString("currentTheme", "") == "christmas")
        {
            newPipe = Instantiate(pipeXmas);
        }
        else
        {
            newPipe = Instantiate(pipeOrg);
        }
        newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-yukseklik, yukseklik), 0);
    }

    void Update()
    {
        if (timer > maxTime)
        {
            if (PlayerPrefs.GetString("currentTheme", "") == "christmas")
            {
                newPipe = Instantiate(pipeXmas);
            }
            else
            {
                newPipe = Instantiate(pipeOrg);
            }
            newPipe.transform.position = transform.position + new Vector3(0, Random.Range(-yukseklik, yukseklik), 0);
            Destroy(newPipe,10);
            timer = 0;
        }

        timer += Time.deltaTime;
    }
}
