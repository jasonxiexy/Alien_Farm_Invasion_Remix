using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class trapThings : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.parent != null && other.transform.parent == transform)
        {
            // The trigger event was caused by a child object's collider.
            Debug.Log("Child collider triggered!");
        }
    }
}
