using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_trap : MonoBehaviour
{
    public static bool active = false;
    private float speed = 20f;
    private float yLimit = 13f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (active)
        {
            Vector3 targetPosition = transform.position;
            targetPosition.y += 10f; // Replace 10f with the constant speed you want the stone to fall at
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (transform.position.y > yLimit)
            {
                Destroy(gameObject);
            }
        }
    }
}
