using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : Enemy
{
	[SerializeField] private float horizontalSpeed = 5.0f;
	[SerializeField] private float frequency = 1.0f;
	[SerializeField] private float amplitude = 0.0f;

	private Vector3 initialAxis;
	private Vector3 initialPosition;
	private float timer = 0.0f;

	private new void Start()
	{
		base.Start();
		initialPosition = transform.position;
		initialAxis = transform.right;
	}

	private void Update()
	{
		if (canMove)
		{
			SinMove();
			timer += Time.deltaTime;
		}
	}
	
	private void SinMove()
	{
		initialPosition += transform.up * Time.deltaTime * horizontalSpeed;
		transform.position = initialPosition + initialAxis * Mathf.Sin(timer * frequency) * amplitude;
	}
}