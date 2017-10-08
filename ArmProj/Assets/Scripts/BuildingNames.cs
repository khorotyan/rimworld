using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class BuildingNames : MonoBehaviour {

	public GameObject NameMenu;
	public Text text;

	void Start () {
	
	}

	void Update () {
	
	}

	void OnTriggerEnter2D(Collider2D col)
	{
		if (col.tag == "hyu") {
			text.text = "Կապույտ Մրրիկ Հյուրանոց ";
			NameMenu.SetActive (true);
		}if (col.tag == "gyu") {
			text.text = "Գյուղապետարան";
			NameMenu.SetActive (true);
		}if (col.tag == "ash") {
			text.text = "Հին Աշտարակ";
			NameMenu.SetActive (true);
		}if (col.tag == "pah") {
			text.text = "Պահակի Տուն ";
			NameMenu.SetActive (true);
		}if (col.tag == "han") {
			text.text = "Հանք, Կողմնակի անձանց մուտքը խստիվ արգելվում է!";
			NameMenu.SetActive (true);
		}if (col.tag == "ata") {
			text.text = "Ատաղտագործ";
			NameMenu.SetActive (true);
		}if (col.tag == "toGyu") {
			text.text = "Ցանկանում ես պահել գանձը`\nԳնա դեպի նավակը";
			NameMenu.SetActive (true);
		}if (col.tag == "toNav") {
			text.text = "Ցանկանում ես կիսել գանձը մյուսների հետ`\nԳնա դեպի գյուղապետարան";
			NameMenu.SetActive (true);
		}

	}

	void OnTriggerExit2D(Collider2D col)
	{
		if (col.tag == "hyu") {
			//text.text = "";
			NameMenu.SetActive (false);
		}if (col.tag == "gyu") {
			//text.text = "";
			NameMenu.SetActive (false);
		}if (col.tag == "ash") {
			//text.text = "";
			NameMenu.SetActive (false);
		}if (col.tag == "pah") {
			//text.text = "";
			NameMenu.SetActive (false);
		}if (col.tag == "han") {
			//text.text = "";
			NameMenu.SetActive (false);
		}if (col.tag == "ata") {
			//text.text = "";
			NameMenu.SetActive (false);
		}if (col.tag == "toGyu") {
			//text.text = "";
			NameMenu.SetActive (false);
		}if (col.tag == "toNav") {
			//text.text = "";
			NameMenu.SetActive (false);
		}
			
	}
}
