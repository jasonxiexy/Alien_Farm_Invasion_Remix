using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoneManager : MonoBehaviour
{
    public GameObject Stone;
    public void SpawnStone()
    {
        GameObject stone = Instantiate(Stone, transform); 
        stone.transform.position = new Vector3(107f, 12f,  0);
    }
}


