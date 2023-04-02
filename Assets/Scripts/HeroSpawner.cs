using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeroSpawner : MonoBehaviour
{
    public GameObject heroPrefab;

    public void SpawnHero()
    {
        GameObject hero = Instantiate(heroPrefab, transform);
        hero.transform.position = new Vector3(127.11f, 12f, 0);
    }
}
