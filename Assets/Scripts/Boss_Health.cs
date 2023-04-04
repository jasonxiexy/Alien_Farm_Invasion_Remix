using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss_Health : MonoBehaviour
{
	public int health = 500;

	//public GameObject deathEffect;

	public bool isInvulnerable = false;

	public Health healthUI;

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

	//void OnTriggerEnter2D(Collider2D hitInfo)
	//{
	//	Boss_Health enemy = hitInfo.GetComponent<Boss_Health>();


	//	if (enemy != null)
	//	{
	//		enemy.TakeDamage(damage);
	//	}



		//Instantiate(impactEffect, transform.position, transform.rotation);

	//	Destroy(gameObject);
	//}

	void Die()
	{
		//Instantiate(deathEffect, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
