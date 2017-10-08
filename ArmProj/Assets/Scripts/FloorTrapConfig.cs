using UnityEngine;
using System.Collections;

public class FloorTrapConfig : MonoBehaviour {

	bool switched = false;
	BoxCollider2D bc;

	public GameObject _norm;
	public GameObject _switched;

	void Start () {
		bc = GetComponent<BoxCollider2D> ();
	}

	void Update () {

	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "Player") 
		{
			if (switched == false) 
			{
				switched = true;
				bc.isTrigger = false;
				_norm.SetActive (false);
				_switched.SetActive (true);
			} 
		}
	}
}
