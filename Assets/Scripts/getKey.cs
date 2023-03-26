using UnityEngine;


public class getKey : MonoBehaviour
{
    // The key prefab that will be spawned
    public GameObject keyPrefab;

    private int canSpawnKey = 0;

    void Update()
    {
        if (canSpawnKey <= 2)
            {
                if(canSpawnKey == 1){

                }else if(canSpawnKey == 2){
                    Vector3 keyPosition = transform.position + transform.right * 5f + Vector3.down * 1.5f;
                    Instantiate(keyPrefab, keyPosition, Quaternion.identity);
                    canSpawnKey++;
                }
                // Spawn a key in front of the player

                // Disable key spawning until the player touches the ground again
            }

            // Make the player jump
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        // Check if the player collides with a grid
        if (other.gameObject.tag == "Player")
        {
            // Enable key spawning
            //Debug.Log(canSpawnKey);
            canSpawnKey++;
        }
    }
}