using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class PipeMovement : MonoBehaviour
{
    public float speed;

    
    void Update()
    {
        transform.position += Vector3.left * speed * Time.deltaTime;
    }
}
