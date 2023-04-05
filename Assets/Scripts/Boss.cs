using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Boss : MonoBehaviour
{
	private Transform player;

	public bool isFlipped = false;

	public Transform pointA;
	public Transform pointB;
	public float moveSpeed = 2f;

	public void LookAtPlayer()
	{
		Vector3 flipped = transform.localScale;
		flipped.z *= -1f;

		if (transform.position.x > player.position.x && isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = false;
		}
		else if (transform.position.x < player.position.x && !isFlipped)
		{
			transform.localScale = flipped;
			transform.Rotate(0f, 180f, 0f);
			isFlipped = true;
		}
	}

    private Vector2 targetPosition;

void Start()
{
    // Start by moving towards point A
    targetPosition = pointA.position;
}

void Update()
{
    // Move towards the current target position
    transform.position = Vector2.MoveTowards(transform.position, targetPosition, moveSpeed * Time.deltaTime);

    // If we've reached the current target position, switch to the other one
    if (Vector2.Distance(transform.position, targetPosition) < 0.1f)
    {
        targetPosition = (targetPosition == (Vector2)pointA.position) ? pointB.position : pointA.position;
    }

}
}


