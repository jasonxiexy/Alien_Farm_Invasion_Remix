using UnityEngine;


public class getKey : MonoBehaviour
{
    // The key prefab that will be spawned
    public GameObject keyPrefab;
    public GameObject skill;
    private int canSpawnKey = 0;
    private bool getbook= true;
    public static GameObject thebook;

    void Update()
    {
        if (canSpawnKey <= 2)
         {
                if(canSpawnKey == 1 && getbook){
                    Vector3 skill_position = transform.position + transform.right * 5f + Vector3.down * 1.5f;
                    thebook = Instantiate(skill, skill_position, Quaternion.identity);
                    getbook = false;
                }
                else if(canSpawnKey == 2){
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
        if (other.gameObject.tag == "player")
        {
            // Enable key spawning
            //Debug.Log(canSpawnKey);
            canSpawnKey++;
        }
    }
    // private GameObject getBook()
    // {
    //     return book;
    // }
}