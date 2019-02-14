using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : BasicObject
{
	[SerializeField] private int damage = 10;
	[SerializeField] private float delayTime = 0.0f;
	[SerializeField] private bool isDestructibleByPlayer = false;
	[SerializeField] private float lifeTime = -1.0f;

	protected bool canMove = false;

	protected new void Start()
	{
		base.Start();
		if (lifeTime > 0)
		{
			Destroy(gameObject, lifeTime);
		}

		StartCoroutine(DelayMove(delayTime));
	}

	public int Damage
	{
		get { return damage; }
	}

	public bool IsDestructibleByPlayer
	{
		get { return isDestructibleByPlayer; }
	}

	private IEnumerator DelayMove(float delay)
	{
		yield return new WaitForSeconds(delay);
		canMove = true;
	}
}