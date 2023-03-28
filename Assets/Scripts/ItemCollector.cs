using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ItemCollector : MonoBehaviour
{

    private int gems = 0;
    private int key = 0;

    [SerializeField] private Text GemsText;
    [SerializeField] private AudioSource collectSoundEffect;

    [SerializeField] private Text keyText;


    public void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Gem"))
        {
            collectSoundEffect.Play();
            Destroy(collision.gameObject);
            gems++;
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
