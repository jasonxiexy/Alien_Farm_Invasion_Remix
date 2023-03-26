using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDistance : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float distanceThreshold = 30f;

    void Update()
    {
        if (Vector3.Distance(transform.position, target.position) > distanceThreshold)
        {
            
            Destroy(gameObject);
        }
    }
}


