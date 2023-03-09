using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class switchPlayer : MonoBehaviour
{

    [SerializeField] GameObject avatar1, avatar2, avatar3;
    int whichAvatarIsOn = 1;


    // Start is called before the first frame update
    void Start()
    {

        avatar1.gameObject.SetActive(true);
        avatar2.gameObject.SetActive(false);
        avatar3.gameObject.SetActive(false);

    }

    // Update is called once per frame
    void Update()
    {
        //SwitchCharacter();

    }

    private void SwitchCharacter()
    {
        if (Input.GetKeyDown("Alpha1"))
        {
            whichAvatarIsOn = 1;

            avatar1.gameObject.SetActive(true);
            avatar2.gameObject.SetActive(false);
            avatar3.gameObject.SetActive(false);
        }
        else if (Input.GetKeyDown("Alpha2"))
        {
            whichAvatarIsOn = 2;

            avatar1.gameObject.SetActive(false);
            avatar2.gameObject.SetActive(true);
            avatar3.gameObject.SetActive(false);

        }
        else if (Input.GetKeyDown("Alpha3"))
        {
            whichAvatarIsOn = 3;
            avatar1.gameObject.SetActive(false);
            avatar2.gameObject.SetActive(false);
            avatar3.gameObject.SetActive(true);
        }
    }
}
