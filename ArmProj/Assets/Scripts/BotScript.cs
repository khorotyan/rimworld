using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BotScript : MonoBehaviour 
{
	public GameObject upCollider;
	public GameObject downCollider;
	public GameObject leftCollider;
	public GameObject rightCollider;

	public bool upColliding = false;
	public bool downColliding = false;
	public bool leftColliding = false;
	public bool rightColliding = false;

	DirectionDetection upDect; 
	DirectionDetection downDect; 
	DirectionDetection leftDect; 
	DirectionDetection rightDect; 

	Vector2 randDir;

	bool collided = false;
	Animator anim;
	Vector2 startPoint;
	Rigidbody2D rig;

	Vector2[] noUp;
	Vector2[] noDown;
	Vector2[] noLeft;
	Vector2[] noRight;
	Vector2[] allDir;

	bool dirChosen = false;
	bool canMove = true;

	bool waited = false;
	float waitTime = 0; 

	enum Direction 
	{
		Up,
		Down,
		Left,
		Right
	}
	Direction direction;

	void Start ()
	{
		startPoint = transform.position;
		rig = GetComponent<Rigidbody2D> ();
		anim = GetComponent<Animator> ();

		noUp = new Vector2[] {Vector2.down, Vector2.left, Vector2.right };
		noDown = new Vector2[] {Vector2.up, Vector2.left, Vector2.right };
		noLeft = new Vector2[] {Vector2.up, Vector2.down, Vector2.right };
		noRight = new Vector2[] {Vector2.up, Vector2.down, Vector2.left };
		allDir = new Vector2[] {Vector2.up, Vector2.down, Vector2.left, Vector2.right };

		upDect = (DirectionDetection) upCollider.GetComponent(typeof(DirectionDetection));
		downDect = (DirectionDetection)downCollider.GetComponent (typeof(DirectionDetection));
		leftDect = (DirectionDetection)leftCollider.GetComponent (typeof(DirectionDetection));
		rightDect = (DirectionDetection)rightCollider.GetComponent (typeof(DirectionDetection));

	}

	void FixedUpdate () 
	{
		upColliding = upDect.colliding;
		downColliding = downDect.colliding;
		leftColliding = leftDect.colliding;
		rightColliding = rightDect.colliding;

		if (canMove == true)
		{
			DirectionConfigure ();

			//if (Vector3.Distance (transform.position, startPoint) > 10)
			//	DontLeaveCircle (); //InvokeRepeating("DontLeaveCircle", 0, 1.0f);

			anim.SetBool ("isWalking", true);

			anim.SetFloat ("input_x", randDir.x);
			anim.SetFloat ("input_y", randDir.y);
		}

		if (canMove == false) 
		{
			rig.velocity = new Vector2 (0, 0);
			anim.SetBool ("isWalking", false);
		}
	}

	void DirectionConfigure()
	{

		if (dirChosen == false) 
		{
			if (upColliding == true)
				randDir = noUp [Random.Range (0, 2)];
			else if (downColliding == true)
				randDir = noDown [Random.Range (0, 2)];
			else if (leftColliding == true)
				randDir = noLeft [Random.Range (0, 2)];
			else if (rightColliding == true)
				randDir = noRight [Random.Range (0, 2)];
			else
				randDir = allDir [Random.Range (0, 3)];

			waitTime = 0;
			dirChosen = true;
		}
		else 
		{
			if (waited == true) 
			{
				randDir = allDir [Random.Range (0, 3)];

				if (Vector3.Distance (transform.position, startPoint) > 3)
					DontLeaveCircle ();

				waited = false;
				waitTime = 0;

			}
			else
			{
				waitTime += 1 * Time.deltaTime;

				if (waitTime >= Random.Range(4, 6))
					waited = true;
			}


			
		}

		DirectionChecker ();

		if (collided == true) 
		{
			collided = false;
			dirChosen = false;
		}

		rig.velocity =  (randDir / 3);
	}

	void DontLeaveCircle()
	{
		if (direction == Direction.Up)
			randDir = Vector2.down;
		else if (direction == Direction.Down)
			randDir = Vector2.up;
		else if (direction == Direction.Left)
			randDir = Vector2.right;
		else
			randDir = Vector2.left;

		dirChosen = true;

	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player")
			canMove = false;

		collided = true;

		randDir = -randDir;
	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player")
			canMove = true;
	}
		
	void DirectionChecker()
	{
		if (randDir == Vector2.up)
			direction = Direction.Up;
		else if (randDir == Vector2.down)
			direction = Direction.Down;
		else if (randDir == Vector2.left)
			direction = Direction.Left;
		else if (randDir == Vector2.right)
			direction = Direction.Right;
	}
		
}