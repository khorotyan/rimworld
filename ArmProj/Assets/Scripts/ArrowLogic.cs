using UnityEngine;
using System.Collections;

public class ArrowLogic : MonoBehaviour {

	Transform tr; 
	Rigidbody2D rig;
	float rot;

	void Start () 
	{
		tr = GetComponent<Transform> ();
		rig = GetComponent<Rigidbody2D> ();
		rot = tr.eulerAngles.z - 90;
	}

	// Update is called once per frame
	void Update () 
	{
		//Debug.Log ();
		if (rot > -1 && rot < 1) 
		{
			rig.AddForce (new Vector2 (1f, 0));
		}
		else if (rot > 89 && rot < 91) 
		{
			rig.AddForce (new Vector2 (0, 1f));
		} 
		else if ( rot > 179 && rot < 181) 
		{
			rig.AddForce (new Vector2 (-1f, 0));
		}
		else if ( (rot > 269 && rot < 271) || (rot > -91 && rot < 89) ) 
		{
			rig.AddForce (new Vector2 (0, -1f));
		}
	}

	void OnCollisionEnter2D()
	{
		Destroy (gameObject);
	}

}
		