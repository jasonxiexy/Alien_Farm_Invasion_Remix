using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    public GameObject heroPrefab;
    public Transform t;

    public void SpawnHero()
    {   
        GameObject hero = Instantiate(heroPrefab, transform);
        if (t.position.x < 20){
            hero.transform.position = new Vector3(-2.13f, 1.35f, 0);
        }
        else if (t.position.x >= 20){
            hero.transform.position = new Vector3(-21.84f, -12.79f, 0);
        }
        else{
        hero.transform.position = new Vector3(127.11f, 12f, 0);
        }
    }
}
