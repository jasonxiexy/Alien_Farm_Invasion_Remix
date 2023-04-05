using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;




public class ItemCollector : MonoBehaviour
{

    private int gems = 0;
    private int key = 0;
   

    [SerializeField] private Text GemsText;
    [SerializeField] private AudioSource collectSoundEffect;

    [SerializeField] private Text keyText;


    public void Start()
    {
        if (SceneManager.GetActiveScene().buildIndex == 5)
        {
            gems = gem_level_3.gem_for_3;
            GemsText.text = "Gems: " + gems;
        }
    }



    public void OnTriggerEnter2D(Collider2D collision)
    {


        if (collision.gameObject.CompareTag("Gem"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            gems++;
            
            if(SceneManager.GetActiveScene().buildIndex == 3)
            {
                gem_level_3.gem_for_3 = gems;
            }
            GemsText.text = "Gems: " + gems;


        }

        if (collision.gameObject.CompareTag("key") && key == 0)
        {
            collectSoundEffect.Play();
            //Destroy(collision.gameObject);
            key++;
            keyText.text = "Key: " + key;
        }
    }
}