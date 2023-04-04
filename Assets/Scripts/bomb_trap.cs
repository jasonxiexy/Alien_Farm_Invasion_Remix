using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class bomb_trap : MonoBehaviour
{
    public static bool active = false;
    private float speed = 20f;
    private float yLimit = 13f;
    //public static GameObject bomb1;
    public GameObject bomb1;

    // Update is called once per frame
    void Start()
    {
        
  
    }
    void Update()
    {
        if (active)
        {
            Vector3 targetPosition = transform.position;
            targetPosition.y += 10f; // Replace 10f with the constant speed you want the stone to fall at
            transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);

            if (transform.position.y > yLimit)
            {
                //Destroy(gameObject);
                active = false;

            }
        }
    }
    //public static void restart()
    //{
    //    bomb1 = Resources.Load<GameObject>("Prefabs/bomb");
    //    Vector3 targetPosition;
    //    targetPosition.x = 142.26f;
    //    targetPosition.y = -7.14f;
    //    targetPosition.z = 0.1596006f;
    //    Instantiate(bomb1, targetPosition, Quaternion.identity);
    //    active = false;
    //}
}
