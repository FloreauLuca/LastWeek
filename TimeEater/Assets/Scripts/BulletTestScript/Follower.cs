using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Follower : Enemy
{
	[SerializeField] private Player player;
	[SerializeField] private float speed = 5.0f;
	[SerializeField] private float distanceMinimum = 5.0f;
	[SerializeField] private bool noTurn = false;

	private new void Start()
	{
		base.Start();
		player = FindObjectOfType<Player>();
		Rotate();
	}

	private void Update()
	{
		CheckClose();
		Rotate();
		if (canMove)
		{
			transform.Translate(Vector3.up * speed * Time.deltaTime);
		}
	}

	//checks if close enough from player, if so, disable turning
	private void CheckClose()
	{
		if (speed > 0 && (player.transform.position - transform.position).magnitude < distanceMinimum)
		{
			noTurn = true;
		}
	}

	//rotates instantaneously the follower in the direction of the player
	private void Rotate()
	{
		if (!noTurn)
		{
			transform.up = player.transform.position - transform.position;
		}
	}
}