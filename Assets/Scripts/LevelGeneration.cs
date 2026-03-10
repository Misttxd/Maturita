using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelGeneration : MonoBehaviour
{
    public GameObject[] objects;
    
    void Start()
    {
        int random = Random.Range(0, objects.Length);
        Instantiate(objects[random], transform.position, Quaternion.identity /*=no rotarion*/);
    }
}
