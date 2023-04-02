using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    public GameObject bomb1;
    public GameObject bomb2;
    public GameObject bomb3;
    public GameObject player;
    private Rigidbody2D rb;
    private Animator anim;
    public PlayerHealth health;

    [SerializeField] AudioSource deathSoundEffect;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap")){
            Debug.Log("lala");
            if (collision.gameObject.name == bomb1.name || collision.gameObject.name == bomb2.name || collision.gameObject.name == bomb3.name)
            {
                Debug.Log("gg");
                anim.SetTrigger("Death");
                transform.parent.GetComponent<HeroSpawner>().SpawnHero();
            }
            Die();
            StartCoroutine(WaitAndRespawn(collision));
            
            // Vector3   rebornP = collision.transform.parent.GetChild(0).transform.position;
            // Debug.Log("Parent function called");
            // transform.position = rebornP;
            // health.damage();
        }
    }

    private IEnumerator WaitAndRespawn(Collision2D collision)
{
    // Wait for 1 second
    if (health.currentHealth == 0) RestartLevel();
    yield return new WaitForSeconds(1f);

    // Get the respawn point from the parent object
    Vector3 respawnPoint = collision.transform.GetChild(0).transform.position;
    Debug.Log("Parent function called");
    transform.position = respawnPoint;

    // Damage the player's health
    health.damage();
}

    private void Die()
    {
        deathSoundEffect.Play();
        //rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
