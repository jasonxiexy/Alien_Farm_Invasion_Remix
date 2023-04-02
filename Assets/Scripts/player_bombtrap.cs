using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class player_bombtrap : MonoBehaviour
{ 
    // Start is called before the first frame update
    public float triggerXValue = 136f;
    public GameObject trapObject;
    private bool door = true;

    void Update()
    {
        if (transform.position.x >= triggerXValue && transform.position.x<= 150f)
        {
            ActivateTrap();
        }
        else if (transform.position.x >= 157f && transform.position.x  <= 170f)
        {
            bomb2.active = true;
        }else if(transform.position.x >= 177f && transform.position.x <= 180f)
        {
            spike2.active = true;
        }
        if(SceneManager.GetActiveScene().buildIndex == 4 && transform.position.x >= 20f && door)
        {
            Closedoor.active = true;
            door = false;
        }
    }

    void ActivateTrap()
    {
        bomb_trap.active = true;
        // You can add additional code here to play a sound effect, animate the trap, etc.
    }
}
