using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class CloudSpawner : MonoBehaviour
{
	[SerializeField] private GameObject[] clouds;
	[SerializeField] private float delayStart = 0.0f;
	[SerializeField] private float minInterval = 1.0f;
	[SerializeField] private float maxInterval = 4.0f;
	[SerializeField] private GameObject leftMaxPos;
	[SerializeField] private GameObject rightMaxPos;
	
	private GameObject currentCloud;

	private void Start()
	{
		if (minInterval > maxInterval)
		{
			minInterval = maxInterval;
		}
		currentCloud = clouds[0];

		StartCoroutine(Spawner());
	}

	private IEnumerator Spawner()
	{
		yield return new WaitForSeconds(delayStart);

		for (int i=0;;i++)
		{
			var x = Random.Range(leftMaxPos.transform.position.x, rightMaxPos.transform.position.x);
			var y = Random.Range(leftMaxPos.transform.position.y, rightMaxPos.transform.position.y);
			Instantiate(currentCloud, new Vector2(x, y), transform.rotation,transform);
			yield return new WaitForSeconds(Random.Range(minInterval, maxInterval));
		}
	}

	public void ChangeColor(int index)
	{
		currentCloud = clouds[index];
	}
}