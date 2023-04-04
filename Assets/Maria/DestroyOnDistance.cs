// using System.Diagnostics;
// using System.Collections;
// using System.Collections.Generic;
using UnityEngine;

public class DestroyOnDistance : MonoBehaviour
{
    // Start is called before the first frame update
    public Transform target;
    public float distanceThreshold = 30f;

    void Update()
    {
        Debug.Log(transform.position);
        Debug.Log(target.position);
        if (Vector3.Distance(transform.position, target.position) > distanceThreshold)
        {
            
            Destroy(gameObject);
        }
        // if (Mathf.Abs(transform.position.x - target.position.x) > distanceThreshold)
        //         {
        //             Destroy(gameObject);
        //         }
    }
}


