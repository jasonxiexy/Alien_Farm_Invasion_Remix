using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class moving_enemy : MonoBehaviour
{
    // Start is called before the first frame update
    [SerializeField] private GameObject[] waypoints;
    private int currentWaypointIndex = 0;

    // The force to apply to make the object jump
    private float jumpHeight = 0.5f;
    public GameObject player;
    private float dealth_force;
    private Rigidbody2D playerBody;
    private Enemy_Health health;

    [SerializeField] private float speed = 2f;


    // float v = Mathf.Sqrt(2.0f * jumpHeight * Physics2D.gravity.magnitude * gravityScale);
    // float upwardForce = rb.mass * v / Time.fixedDeltaTime;
    // rb.AddForce(Vector2.up * upwardForce, ForceMode2D.Impulse);


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.name == "Owlet")
        {
            //Destroy(collision.gameObject);
            //monster jump by force
            
            float jumpHeight = 1.5f;
            float jumpDuration = 0.5f;
            float gravity = Physics2D.gravity.magnitude;

        //     float vi = (jumpHeight - 0.5f * Physics2D.gravity.magnitude * jumpTime * jumpTime) / jumpTime;
        // float force = rb.mass * (vi - rb.velocity.y) / jumpTime;
            
            float initialVelocity = (jumpHeight - 0.5f * gravity * jumpDuration * jumpDuration) / jumpDuration;
            float force = playerBody.mass * (initialVelocity - playerBody.velocity.y) / jumpDuration;        
            playerBody.AddForce(new Vector2(0, force), ForceMode2D.Impulse);
            health.damage();
            if(health.currentHealth == 0) gameObject.SetActive(false);
            
            
        }
        
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.CompareTag("bullet1")){

            health.damage();
            if(health.currentHealth == 0) gameObject.SetActive(false);
        }

    }

    private void Start(){
        health = transform.GetComponent<Enemy_Health>();
        playerBody = player.GetComponent<Rigidbody2D>();
        dealth_force = Mathf.Sqrt(2f * Physics2D.gravity.magnitude * jumpHeight * playerBody.mass);
        
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
