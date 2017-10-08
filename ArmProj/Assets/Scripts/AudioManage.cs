using UnityEngine;
using System.Collections;

public class AudioManage : MonoBehaviour {

	public AudioClip indoors;
	public AudioClip outdoors1;
	public AudioClip outdoors2;

	AudioSource _audio;
	DoorTeleportSystem dts;

    void Start () {
		_audio = GetComponent<AudioSource>();
		dts = FindObjectOfType<DoorTeleportSystem> ();
	}

	void Update () {
	
	}

	void Checker()
	{
		if (dts.entered == true) {
			_audio.clip = indoors;
		} else
			_audio.clip = outdoors1;

		_audio.Play ();
	}
}
