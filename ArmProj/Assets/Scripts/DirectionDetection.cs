using UnityEngine;
using System.Collections;

public class DirectionDetection : MonoBehaviour {

	public bool colliding = false;

	void Start()
	{

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		colliding = true;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		colliding = false;
	}
}
