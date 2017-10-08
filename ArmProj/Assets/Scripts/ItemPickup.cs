using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class ItemPickup : MonoBehaviour {

	WalkScript walkSc;
	public GameObject notePanel;

	public Text noteInfo;
	public Text endText;
	public Text startText;
	public TextAsset startAsset;

	public GameObject door_locked1;
	public GameObject door_unlocked1;
	bool hasKey1 = false;
	bool canShowTreasure = false;
	[Space(10)]
	public GameObject endCanvas;
	public GameObject startCanvas;
	public GameObject signGyu;
	public GameObject signNav;
	public GameObject Gyu;
	public GameObject Nav;
	[Space(10)]
	public TextAsset note1Text;
	public TextAsset note2Text;
	public TextAsset note3Text;
	public TextAsset note4Text;
	public TextAsset note5Text;
	public TextAsset note6Text;
	public TextAsset note7Text;
	[Space(10)]
	public GameObject ItemNote1;
	public GameObject ItemNote2;
	public GameObject ItemNote3;
	public GameObject ItemNote4;
	public GameObject ItemNote5;
	public GameObject ItemNote6;
	public GameObject ItemNote7;
	[Space(10)]
	public GameObject treasure;
	public GameObject key1;
	public GameObject key2;
	public GameObject key3;
	public GameObject note1;
	public GameObject note2;
	public GameObject note3;
	public GameObject note4;
	public GameObject note5;
	public GameObject note6;
	public GameObject note7;

	public int itemSize = 4;

	void Start () {
		walkSc = FindObjectOfType<WalkScript> ();
		//startText.text = startAsset.text;
	}

	void Update () {
		DoorConfigure1 ();

		if (canShowTreasure == true) 
		{
			key1.SetActive (false);
			treasure.SetActive (true);
		}
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "items") 
		{
			if (col.gameObject.name == key1.name) {
				key1.SetActive (true);
				hasKey1 = true;
			} else if (col.gameObject.name == note1.name) {
				note1.SetActive (true);
				ItemNote2.SetActive (true);
			} else if (col.gameObject.name == note2.name) {
				note2.SetActive (true);
				ItemNote3.SetActive (true);
			} else if (col.gameObject.name == note3.name) {
				note3.SetActive (true);
				ItemNote4.SetActive (true);
			} else if (col.gameObject.name == note4.name) {
				note4.SetActive (true);
				ItemNote5.SetActive (true);
			} else if (col.gameObject.name == note5.name) {
				note5.SetActive (true);
				ItemNote6.SetActive (true);
			} else if (col.gameObject.name == note6.name) {
				note6.SetActive (true);
				ItemNote7.SetActive (true);
			} else if (col.gameObject.name == note7.name) {
				note7.SetActive (true);
				signGyu.SetActive (true);
				signNav.SetActive (true);
				Gyu.SetActive (true);
				Nav.SetActive (true);
			}


			col.gameObject.SetActive (false);
		}

		if (col.tag == "endGyu") 
		{
			endText.text = " Ջերվիսը հանձնեց գանձերը գյուղապետին, ստանալով իրեն խոստացած մասը: " +
				"Ժամանակն էր լքելու Ֆէգսբուրգը: Մի փոքր տխրության զգացումով, " +
				"նա գնաց դեպի նավը, խոստանալով գյուղացիներին կրկին այցելել իրենց:";

			walkSc.canMove = false;
			endCanvas.SetActive (true);
		} 
		else if (col.tag == "EndNav")
		{
			endText.text = " Ջերվիսը շտապ նստեց նավը, հույս ունենալով, որ գյուղացիները չնկատեցին իր ձեռքին եղած արկղը:" +
				" Անչափ հարստացած, նա վերադառնում էր քաղաք: " +
				"Միևնույնն է այս տարօրինակ գյուղի բնակիչները երբեք իրեն չեն գտնի:";

			walkSc.canMove = false;
			endCanvas.SetActive (true);
		}
	}

	void DoorConfigure1()
	{
		if (door_locked1 != null) 
		{
			if (Vector2.Distance(transform.position, door_locked1.transform.position) < 0.3 && hasKey1 == true)
			{
				if (door_unlocked1 != null) 
				{
					door_unlocked1.SetActive (true);
					door_locked1.SetActive (false);

					key1.SetActive (false);
				}

				if (Input.GetKeyDown ("e")) 
				{
					transform.position = new Vector3 (transform.position.x, transform.position.y + 10, -1);
				}
			}
		}
	}

	public void OnTreasureClick()
	{
		canShowTreasure = true;
	}

	public void OnNote1Click()
	{
		notePanel.SetActive (true);
		noteInfo.text = note1Text.text;
	}

	public void OnNote2Click()
	{
		notePanel.SetActive (true);
		noteInfo.text = note2Text.text;
	}

	public void OnNote3Click()
	{
		notePanel.SetActive (true);
		noteInfo.text = note3Text.text;
	}

	public void OnNote4Click()
	{
		notePanel.SetActive (true);
		noteInfo.text = note4Text.text;
	}

	public void OnNote5Click()
	{
		notePanel.SetActive (true);
		noteInfo.text = note5Text.text;
	}

	public void OnNote6Click()
	{
		notePanel.SetActive (true);
		noteInfo.text = note6Text.text;
	}

	public void OnNote7Click()
	{
		notePanel.SetActive (true);
		noteInfo.text = note7Text.text;
	}

	public void ClosePanel()
	{
		notePanel.SetActive (false);
	}

	public void toMainMenu()
	{
		SceneManager.LoadScene ("MainScreen");
	}

	public void CloseStartText()
	{
		startCanvas.SetActive (false);
	}
}
