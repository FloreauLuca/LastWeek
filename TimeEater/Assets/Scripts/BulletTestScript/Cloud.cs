using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class Cloud : BasicObject
{
	[SerializeField] private Sprite[] sprites;
	[SerializeField] private float speed = 10;
	[SerializeField] private float rangeSpeed = 2;

	private SpriteRenderer mySpriteRender;


	private new void Start()
	{
		base.Start();
		mySpriteRender = GetComponentInChildren<SpriteRenderer>();

		ChangeSprite(Random.Range(0, sprites.Length - 1));
		speed += Random.Range(-rangeSpeed, rangeSpeed);

		//objects closer seem to be moving faster
		mySpriteRender.sortingOrder = (int) speed;
	}

	private void Update()
	{
		transform.position = transform.position + Vector3.down * speed * Time.deltaTime;
	}

	//ChangeSprite based on its index
	public void ChangeSprite(int index)
	{
		if (index < sprites.Length && index >= 0)
		{
			mySpriteRender.sprite = sprites[index];
		}
		else
		{
			Debug.Log("ChangeSprite : wrong index for cloud sprite entered");
		}
	}
}