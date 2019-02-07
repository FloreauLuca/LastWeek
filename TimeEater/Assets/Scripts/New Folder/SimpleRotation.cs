using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleRotation : MonoBehaviour
{
	[SerializeField] private Vector3 rotationAxis;
	[SerializeField] private float rotationSpeed=10;
	
	void Update () {
		transform.Rotate(rotationAxis, rotationSpeed*Time.deltaTime);
	}
}
