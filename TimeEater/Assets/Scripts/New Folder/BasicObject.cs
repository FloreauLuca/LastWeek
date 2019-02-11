using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicObject : MonoBehaviour
{
	private bool hasWaited = false;

	[SerializeField] private float timeAllowedOutsideOutWindow = 0.5f;

	protected void Start()
	{
		StartCoroutine(Wait(timeAllowedOutsideOutWindow));
	}
	
	private IEnumerator Wait(float time)
	{
		yield return new WaitForSeconds(time);
		hasWaited = true;
	}

	private void OnBecameInvisible()
	{
		if (hasWaited)
		{
			Destroy(gameObject);
		}
	}
}