using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy_Generate : MonoBehaviour
{

    public GameObject objectPrefab; // assign the prefab in the inspector
    public float interval = 3f; // interval between each instantiation
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("InstantiateObject", interval, interval);
        
    }

    void InstantiateObject()
{
    Instantiate(objectPrefab, transform.position, Quaternion.identity);
}

    // Update is called once per frame
    void Update()
    {
        
    }
}
