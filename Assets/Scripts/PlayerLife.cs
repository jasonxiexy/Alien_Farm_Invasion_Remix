using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerLife : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator anim;
    public PlayerHealth health;
    public PlayerMovement move;

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
            
            rb.bodyType = RigidbodyType2D.Static;
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
    yield return new WaitForSeconds(1f);
    

    // Get the respawn point from the parent object
    Vector3 respawnPoint = collision.transform.GetChild(0).transform.position;
    Debug.Log("Parent function called");
    transform.position = respawnPoint;
    rb.bodyType = RigidbodyType2D.Dynamic;

    // Damage the player's health
    health.damage();

    if (health.currentHealth == 0) RestartLevel();
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
