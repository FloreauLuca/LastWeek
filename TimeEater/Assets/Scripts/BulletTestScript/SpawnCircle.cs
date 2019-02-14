using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnCircle : MonoBehaviour
{
	[SerializeField] private Enemy bulletPrefab;
	[SerializeField] private int numberShots;
	[SerializeField] private int turns = 1;
	[SerializeField] private float radius;
	[SerializeField] private float interval;
	[SerializeField] private Player player;

	private Vector3 initialPlayerPos;

	private void Start()
	{
		player = FindObjectOfType<Player>();
		initialPlayerPos = player.transform.position;

		if (interval > 0)
		{
			StartCoroutine(FireAndWait(interval));
		}
		else
		{
			for (int i = 0; i < numberShots; i++)
			{
				FireSingle();
			}
			Destroy(gameObject);
		}
	}

	//Fire and wait interval time
	private IEnumerator FireAndWait(float time)
	{
		for (int i = 0; i < numberShots*turns; i++)
		{
			FireSingle();
			yield return new WaitForSeconds(time);
		}

		Destroy(gameObject);
	}

	//Fire and then rotate this object
	private void FireSingle()
	{
		Instantiate(bulletPrefab,initialPlayerPos + transform.up * -radius, transform.rotation);
		transform.Rotate(transform.forward, (float) 360 / numberShots);
	}
}