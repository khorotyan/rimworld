using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class StartText : MonoBehaviour {

	public TextAsset theText;
	public Sprite playerImage;

	public int startLine;
	public int endLine;

	TextImporter theTextBox;

	string playerName;

	void Start () {
		playerName = "Ջեռվիս";

		theTextBox = FindObjectOfType<TextImporter> ();
		theTextBox.theImage.sprite = playerImage;
		theTextBox.nameText.text = playerName.ToString ();

		DialogChecker ();
	}
		
	void DialogChecker()
	{
		theTextBox.ReloadScript (theText);
		theTextBox.currentLine = startLine;
		theTextBox.endAtLine = endLine;
		theTextBox.EnableTextBox ();
	}

	void Update()
	{
		if (Input.GetKey(KeyCode.LeftShift) && Input.GetKeyDown(KeyCode.Q))
			SceneManager.LoadScene ("MainScreen");
	}

}
