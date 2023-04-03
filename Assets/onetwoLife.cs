using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class onwtwoLife : MonoBehaviour
{
    public GameObject bomb1;
    public GameObject bomb2;
    public GameObject bomb3;
    public GameObject player;
    private Rigidbody2D rb;
    private Animator anim;
     public PlayerHealth health;

    [SerializeField] AudioSource deathSoundEffect;
    [SerializeField] GameObject replayButton;
    [SerializeField] GameObject pauseButton;
    [SerializeField] GameObject resumeButton;
    [SerializeField] GameObject homeButton;
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
            rb.bodyType = RigidbodyType2D.Static;
            Die();
            StartCoroutine(WaitAndRespawn(collision));
            // if (collision.gameObject.name == bomb1.name || collision.gameObject.name == bomb2.name || collision.gameObject.name == bomb3.name)
            // {
            //     Debug.Log("gg");
            //     anim.SetTrigger("Death");
            //     transform.parent.GetComponent<HeroSpawner>().SpawnHero();
            // }
        }
        //else if (rb.velocity.y < -5)
        //{
        //    Die();
        //}
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

    if (health.currentHealth == 0) {
        replayButton.SetActive(true);
        homeButton.SetActive(true);
    }
}

    private void Die()
    {
        deathSoundEffect.Play();
        //rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
        //replayButton.SetActive(true);
        //homeButton.SetActive(true);
    }

    //private void RestartLevel()
    //{
    //    SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    //}
    public void replay()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

    public void pause()
    {
        Time.timeScale = 0f;
        resumeButton.SetActive(true);
        homeButton.SetActive(true);
    }

    public void resume()
    {
        Time.timeScale = 1f;
        resumeButton.SetActive(false);
        homeButton.SetActive(false);
    }

    public void home()
    {
        SceneManager.LoadScene("Start");
        Time.timeScale = 1f;
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
}
