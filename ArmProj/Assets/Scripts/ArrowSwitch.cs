using UnityEngine;
using System.Collections;

public class ArrowSwitch : MonoBehaviour {

	bool switched = false;

	public GameObject _norm;
	public GameObject _switched;

	void Start () {
		
	}

	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "Player") 
		{
			if (switched == false) 
			{
				switched = true;
				_norm.SetActive (false);
				_switched.SetActive (true);
			} else 
			{
				switched = false;
				_switched.SetActive (false);
				_norm.SetActive (true);
			}
		}
	}

}
