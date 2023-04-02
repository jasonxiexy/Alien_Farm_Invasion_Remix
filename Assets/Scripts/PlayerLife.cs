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
        }
        //else if (rb.velocity.y < -5)
        //{
        //    Die();
        //}
    }

    private void Die()
    {
        deathSoundEffect.Play();
        rb.bodyType = RigidbodyType2D.Static;
        anim.SetTrigger("Death");
    }

    private void RestartLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
