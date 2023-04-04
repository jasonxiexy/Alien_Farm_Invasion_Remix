 using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Weapon : MonoBehaviour
{
    private PlayerLife player;
    public Transform firePoint;
    public GameObject bulletPrefab;
    // Update is called once per frame

    void Start()
    {
        player = FindObjectOfType<PlayerLife>();
    }

    void Update()
    {

        if(player.getWp() || (SceneManager.GetActiveScene().buildIndex==4))
        {
            
            if (Input.GetButtonDown("Fire1"))
            {
                
                Shoot();
            }
        }
    }

    void Shoot ()
    {
        
        //shooting logic
        Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
        

    }
}
