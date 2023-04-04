using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

[ExecuteInEditMode]
public class PlayerLife : MonoBehaviour
{
    public GameObject bomb1;
    public GameObject bomb_2;
    public GameObject bomb3;
    public GameObject spike1;
    public GameObject spike_2;
    public GameObject player;
    private Rigidbody2D rb;
    private Animator anim;
     public PlayerHealth health;
     public Vector3 respawnPoint;
     private bool wp = false;
    public GameObject magicbook;
    private getKey gg;

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
        //respawnPoint = GetComponent<Vector3>();
        gg = FindObjectOfType<getKey>();
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("trap")){
            //Debug.Log("lala");
            rb.bodyType = RigidbodyType2D.Static;
            Die();
            
            // if (transform.position.x >= 128)
            // //if (collision.gameObject.name == bomb1.name || collision.gameObject.name == bomb_2.name || collision.gameObject.name == spike1.name || collision.gameObject.name == spike_2.name)
            // {
            //     //Debug.Log("gg");
            //     //Die();
            //     //this.respawnPoint = new Vector3(127.11f, 1f, 0);
            //     //transform.position = respawnPoint;
            //     //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //     //StartCoroutine(WaitAndRespawn(collision));
            //     //SceneManager.LoadScene(5);
            // }
            StartCoroutine(WaitAndRespawn(collision));
            rb.bodyType = RigidbodyType2D.Dynamic;
     
        }
        if (collision.gameObject.CompareTag("magicbook"))
        {
            this.setWp();
            Destroy(getKey.thebook);
        }
    }


    
     private IEnumerator WaitAndRespawn(Collision2D collision)
{
    // Wait for 1 second
    yield return new WaitForSeconds(1f);
    
    health.damage();

    if (health.currentHealth == 0) {
        replayButton.SetActive(true);
        homeButton.SetActive(true);
       
    }else{
        // Get the respawn point from the parent object
        //Vector3 respawnPoint = collision.transform.GetChild(0).transform.position;


        Debug.Log("Parent function called");
        //transform.position = respawnPoint;
        bomb1.transform.position = new Vector3(137.26f, -9.14f, 0.1596006f);
        bomb1.transform.rotation = Quaternion.identity;
        bomb_trap.active = false;
        bomb_2.transform.position = new Vector3(155.42f, -9.591613f, 0.1596006f);
        bomb_2.transform.rotation = Quaternion.identity; 
        bomb2.active = false;
        spike1.transform.position = new Vector3(166.7182f, -7.311613f, 0.3192011f);
        spike1.transform.rotation = Quaternion.identity;
        spike_2.transform.position = new Vector3(168.8475f, -7.341613f, 0.3192011f);
        spike_2.transform.rotation = Quaternion.identity;
        spike2.active = false;

        if (transform.position.x >= 128)
        //if (collision.gameObject.name == bomb1.name || collision.gameObject.name == bomb_2.name || collision.gameObject.name == spike1.name || collision.gameObject.name == spike_2.name)
        {
            //Debug.Log("gg");
            //Die();
            //this.respawnPoint = new Vector3(127.11f, 1f, 0);
            //transform.position = respawnPoint;
            //SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            //StartCoroutine(WaitAndRespawn(collision));
            SceneManager.LoadScene(5);
        }
        else
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
            Debug.Log("gg");
            
        }
        //        rb.bodyType = RigidbodyType2D.Dynamic;

            
        }

    // Damage the player's health
    
}

    private void Die()//animation
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

    // private void RestartLevel()
    // {
    //     SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    // }
    public void setWp()
    {
        this.wp = true;
    }
    public bool getWp()
    {
        return wp;
    }
}

