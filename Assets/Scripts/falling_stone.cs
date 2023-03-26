using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class falling_stone : MonoBehaviour
{
    public float speed = 9.98f;
    public float yLimit = -12.0f;
    // Start is called before the first frame update


    // Update is called once per frame
    void Update()
    {
        Vector3 targetPosition = transform.position;
        targetPosition.y += -10f;
        transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
        if(transform.position.y < yLimit){
            Destroy(gameObject);
            transform.parent.GetComponent<StoneManager>().SpawnStone();
        }
    }

}
