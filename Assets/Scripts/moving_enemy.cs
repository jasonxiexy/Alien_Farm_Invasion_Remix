using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    [SerializeField] private float speed = 2f;


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Owlet")
        {
            //Destroy(collision.gameObject);
            gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        if (gameObject != null)
        {
            if (Vector2.Distance(waypoints[currentWaypointIndex].transform.position, transform.position) < .1f)
            {
                currentWaypointIndex++;
                if (currentWaypointIndex >= waypoints.Length)
                {
                    currentWaypointIndex = 0;
                }
            }

            transform.position = Vector2.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, Time.deltaTime * speed);
        }
    }
}
