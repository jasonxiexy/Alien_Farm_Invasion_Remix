
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float speed = 20f;
    public Rigidbody2D rb;
    public int damage = 40;
    //public GameObject impactEffect;
    
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    //void OnTriggerEnter2D(Collider2D hitInfo)
    //{
    //    Boss_Health enemy = hitInfo.GetComponent<Boss_Health>();
    //    if (enemy != null)
    //    {
    //        enemy.TakeDamage(damage);
    //    }

    //    Instantiate(impactEffect, transform.position, transform.rotation);

    //    Destroy(gameObject);
    //}


}
