
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    //public GameObject impactEffect;
    // Start is called before the first frame update
    public Transform target;
    public float distanceThreshold = 30f;
    public int damage = 40;

    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    //void Update()
    //{
    //    if (Vector3.Distance(transform.position, target.position) > distanceThreshold)
    //    {

    //        Destroy(gameObject);
    //    }
    //}

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("boss")){
            Boss_Health enemy = collision.GetComponent<Boss_Health>();
            if (enemy != null)
            {
                enemy.TakeDamage(damage);
            }
        }
        


        //Destroy(gameObject);
    }

}
