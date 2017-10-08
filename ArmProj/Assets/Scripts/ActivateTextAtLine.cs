using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class ActivateTextAtLine : MonoBehaviour {

	public TextAsset theText;
	public GameObject player;

	public bool playerStarts = false;
	public Sprite npcImage;
	public Sprite playerImage;
	public Text NPCName;

	public int startLine;
	public int endLine;

	TextImporter theTextBox;

	string playerName;

	void Start () {
		theTextBox = FindObjectOfType<TextImporter> ();
		playerName = "Ջեռվիս";
	}

	void Update () {
	
		DialogChecker ();

	}

	void DialogChecker()
	{
		if (Vector2.Distance(transform.position, player.transform.position) < 0.5)
		{
			if (Input.GetKeyDown (KeyCode.E))
			{
				theTextBox.ReloadScript (theText);
				theTextBox.currentLine = startLine;
				theTextBox.endAtLine = endLine;
				theTextBox.EnableTextBox ();

			}

			if (playerStarts == true) {
				if (theTextBox.currentLine % 2 == 0) {
					theTextBox.theImage.sprite = playerImage;
					theTextBox.nameText.text = playerName.ToString ();
				} else {
					theTextBox.theImage.sprite = npcImage;
					theTextBox.nameText.text = NPCName.text;
				}
			} else {
				if (theTextBox.currentLine % 2 != 0) {
					theTextBox.theImage.sprite = playerImage;
					theTextBox.nameText.text = playerName.ToString ();
				} else {
					theTextBox.theImage.sprite = npcImage;
					theTextBox.nameText.text = NPCName.text;
				}
			}
		}
	}

}
