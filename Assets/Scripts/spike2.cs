using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spike2 : MonoBehaviour
{
    public static bool active = false;
    private float speed = 20f;
    private float yLimit = -2.7f;
    private bool p = true;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (active && p)
        {
            Vector3 targetPosition = transform.position;
            targetPosition.y += 0.5f; // Replace 10f with the constant speed you want the stone to fall at
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (transform.position.y >= yLimit)
            {
                p = false;
                active = false;
            }
        }
    }
}
