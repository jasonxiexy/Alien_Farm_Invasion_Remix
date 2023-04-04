using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static Unity.Burst.Intrinsics.X86;

public class bomb2 : MonoBehaviour
{
    public static bool active = false;
    private float speed = 20f;
    private float yLimit = 10f;
    private bool seond = false;
    public static GameObject bomb;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (active == true && seond == false)
        {
            Debug.Log("yeye");
            Vector3 targetPosition = transform.position;
            targetPosition.y += 10f; // Replace 10f with the constant speed you want the stone to fall at
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (transform.position.y > yLimit)
            {
                active = false;
                seond = true;
            }
        }
        else if (active && seond)
        {
            Vector3 targetPosition = transform.position;
            targetPosition.y = -14f; // Replace 10f with the constant speed you want the stone to fall at
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            if (transform.position.y < -13f)
            {
                //Destroy(gameObject);
                active = false;
            }
        }
    }
    public static void restart()
    {
        bomb = Resources.Load<GameObject>("Prefabs/bomb2");
        Vector3 targetPosition;
        targetPosition.x = 142.26f;
        targetPosition.y = -7.14f;
        targetPosition.z = 0.1596006f;
        Instantiate(bomb, targetPosition, Quaternion.identity);
        active = false;
    }
}
