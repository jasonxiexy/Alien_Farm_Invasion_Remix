using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class finish : MonoBehaviour
{
    //[SerializeField] private
    [SerializeField] bool _isDoorOpenSwitch;
    [SerializeField] bool _isDoorCloseSwitch;

    private AudioSource finishSound;
    public int keyInstance = 0;

    private Animator anim;

    private bool levelCompleted = false;


    // Start is called before the first frame update
    private void Start()
    {
        finishSound = GetComponent<AudioSource>();
        //keyInstance = FindObjectOfType<ItemCollector>().key;
        anim = GetComponent<Animator>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if ((collision.gameObject.name == "Owlet") && (keyInstance == 1))
        if (collision.gameObject.name == "Player" && !levelCompleted)
        {
            //if (CheckKey())
            //{
            //anim.set
            finishSound.Play();
            levelCompleted = true;
            Invoke("CompleteLevel", 2f);

            //}

        }
    }


    private void CompleteLevel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    private bool CheckKey()
    {
        if (keyInstance == 1)
        {
            return true;
        }
        else
        {
            return false;
        }
    }
}
