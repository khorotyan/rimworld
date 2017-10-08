using UnityEngine;
using System.Collections;

public class ArrShoLogic : MonoBehaviour {

	public GameObject gmg;

	public GameObject arrow;
	public float cooldown = 2;

	Transform tr;

	float cooldown_;

	void Start () 
	{
		tr = GetComponent<Transform>();
		cooldown_ = cooldown;
	}

	void Update () 
	{
		if (cooldown_ <= 0 && gmg.activeSelf)
		{
			Instantiate (arrow, transform.position, Quaternion.Euler(tr.eulerAngles.x, tr.eulerAngles.y, tr.eulerAngles.z + 135));
			cooldown_ = cooldown;
		} 
		else
		{
			cooldown_ -= Time.deltaTime;
		}
	}
}
