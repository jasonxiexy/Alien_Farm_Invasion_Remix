using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Detection : MonoBehaviour
{
    GhostAI parentScript;
    public Transform target;
    public LayerMask Obstacle;
    // Start is called before the first frame update
    void Start()
    {
        parentScript = GetComponentInParent<GhostAI>();
        target = parentScript.target;
        
    }

    void OnTriggerStay2D(Collider2D other) {
        if (other.gameObject.CompareTag("player")) {
            Debug.Log("Player INSIDE: " + other.name);
            parentScript.patrolling = false;
           
        }
    }
    void OnTriggerExit2D(Collider2D other) {
        if (other.gameObject.CompareTag("player")) {
            
            Debug.Log("Player Has Left The Trigger Area");
            parentScript.patrolling = true;
        }
    }
}
