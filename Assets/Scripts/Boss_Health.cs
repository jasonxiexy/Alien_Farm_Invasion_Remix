using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
	public int health = 500;

	//public GameObject deathEffect;

	public bool isInvulnerable = false;

	public Health healthUI;



	public bool boss_die = false;

	public GameObject door;
	public GameObject keyPrefab;


	private void Start()
    {
		healthUI.setMax(health);
    }

    public void TakeDamage(int damage)
	{
		if (isInvulnerable)
			return;

		health -= damage;
		healthUI.setHealth(health);

		//if (health <= 200)
		//{
		//	GetComponent<Animator>().SetBool("IsEnraged", true);
		//}

		if (health <= 0)
		{
			Die();
		}
	}


	void Die()
	{
		//Instantiate(deathEffect, transform.position, Quaternion.identity);
		boss_die = true;
		Vector3 door_position = transform.position + transform.up * -4.5f + Vector3.down * 1.5f;

		GameObject childprefab = Instantiate(door, door_position, Quaternion.identity);

		Vector3 keyPosition = transform.position + transform.up * -4f + transform.right * 5f + Vector3.down * 1.5f;
		GameObject keyFab = Instantiate(keyPrefab, keyPosition, Quaternion.identity);

		//Destroy(gameObject);
		gameObject.SetActive(false);
	}


}
