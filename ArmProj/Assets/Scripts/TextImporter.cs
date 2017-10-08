using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class TextImporter : MonoBehaviour {
	
	WalkScript player;

	public GameObject textBox;
	public GameObject startOver;
	public Text theText;
	public Image theImage;
	public Text nameText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine = 1;
	public int endAtLine;
	public bool isActive;

	private bool typing = false;
	private bool cancelTyping = false;
	public float typeSpeed = 0.1f;

	void Start () 
	{
		player = FindObjectOfType<WalkScript> ();

		if (textFile != null) 
		{
			textLines = textFile.text.Split ('\n');
		}

		if (endAtLine == 0) 
		{
			endAtLine = textLines.Length - 1;
		}

		if (isActive)
		{
			EnableTextBox ();
		} 
		else
		{
			DisableTextBox ();
		}

	}

	void Update()
	{
		if (!textBox) 
		{
			return;
		}

		//theText.text = textLines [currentLine];

		if (Input.GetKeyDown(KeyCode.Space) && currentLine < endAtLine)
		{
			if (!typing) 
			{
				currentLine++;

				if (currentLine >= endAtLine) 
				{
					DisableTextBox ();
					if (startOver != null) 
					{
						currentLine = 1;
						startOver.SetActive (false);
					}
				} 
				else 
				{
					StartCoroutine (TextScroll (textLines [currentLine]));
				}
			}
			else if (typing && !cancelTyping)
			{
				cancelTyping = true;
			}
				
		}
	}

	IEnumerator TextScroll (string lineOfText)
	{
		int letter = 0;
		theText.text = "";
		typing = true;
		cancelTyping = false;

		while (typing && !cancelTyping && (letter < lineOfText.Length - 1)) 
		{
			theText.text += lineOfText [letter];
			letter++;
			yield return new WaitForSeconds (typeSpeed);
		}

		theText.text = lineOfText;
		typing = false;
		cancelTyping = false;
	}

	public void EnableTextBox()
	{
		textBox.SetActive (true);
		isActive = true;

		player.canMove = false;

		StartCoroutine (TextScroll (textLines [currentLine]));
	}

	public void DisableTextBox()
	{
		textBox.SetActive (false);

		isActive = false;

		player.canMove = true;
	}

	public void ReloadScript(TextAsset newTextFile)
	{
		if (newTextFile != null) 
		{
			textLines = new string[1];
			textLines = newTextFile.text.Split ('\n');
		}
	}
		
}
