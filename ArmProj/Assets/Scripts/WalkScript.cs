using UnityEngine;
using System.Collections;

public class WalkScript : MonoBehaviour {

	public float Speed;
	public float Horizontal;
	public float Vertical;

	public bool canMove = true;

	Rigidbody2D rig;
	Animator anim;
	float BaseSpeed = 1.5f;

	void Start () 
	{
		rig = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		if (canMove == true) 
		{
			Horizontal = Input.GetAxis ("Horizontal");
			Vertical = Input.GetAxis ("Vertical");

			if (Horizontal == 0 && Vertical == 0)
				anim.SetBool ("isWalking", false);
			else
			{
				anim.SetBool ("isWalking", true);
				anim.SetFloat ("input_x", Horizontal);
				anim.SetFloat ("input_y", Vertical);
			}

			if (Horizontal != 0 && Vertical != 0)
				Speed = BaseSpeed * 0.7f;
			else
				Speed = BaseSpeed;

			rig.velocity = new Vector2 (Horizontal * Speed, Vertical * Speed);
		}

		if (canMove == false) 
		{
			Vertical = 0;
			Horizontal = 0;
			rig.velocity = new Vector2 (0, 0);
			anim.SetBool ("isWalking", false);
		}
			
	}
}
