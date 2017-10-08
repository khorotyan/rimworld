using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartConfigure : MonoBehaviour {

	public GameObject menuItems;
	public GameObject options;
	public GameObject howToPlay;
	public GameObject aboutUs;

	void Start () {
	
	}

	public void StartGame()
	{
		SceneManager.LoadScene ("TestScene");
	}

	public void ShowHowToPlay()
	{
		howToPlay.SetActive (true);
		menuItems.SetActive (false);
	}

	public void ShowOptions()
	{
		menuItems.SetActive (false);
		options.SetActive (true);
	}

	public void ShowAboutUs()
	{
		menuItems.SetActive (false);
		aboutUs.SetActive (true);
	}

	public void CallOnExit()
	{
		Application.Quit ();
	}

	public void CallOnBack()
	{
		if (aboutUs.activeSelf == true)
			aboutUs.SetActive (false);

		if (options.activeSelf == true)
			options.SetActive (false);
		
		if (howToPlay.activeSelf == true)
			howToPlay.SetActive (false);
		
		menuItems.SetActive (true);
	}
}
