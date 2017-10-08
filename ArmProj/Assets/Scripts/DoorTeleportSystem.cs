using UnityEngine;
using System.Collections;

public class DoorTeleportSystem : MonoBehaviour {

	public GameObject player;
	public GameObject door1;
	public GameObject door2;

	bool canEnter = false;
	public bool entered = false;

	void Start () {
		
	}

	void Update () {
		TeleportConfig ();
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player") 
		{
			canEnter = true;
		}
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player") {
			canEnter = false;
		}

	}

	void TeleportConfig()
	{
		if (canEnter == true && Input.GetKeyDown("e"))
		{
			if (gameObject.name == "Door1") 
			{
				player.transform.position = new Vector3(door2.transform.position.x, door2.transform.position.y + 0.2f, -1);
				entered = true;
			}
			else if (gameObject.name == "Door2") 
			{
				player.transform.position = new Vector3(door1.transform.position.x, door1.transform.position.y - 0.2f, -1);
				entered = false;
			}

		}
	}
}
