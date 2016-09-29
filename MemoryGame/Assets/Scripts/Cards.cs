using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Cards : MonoBehaviour
{
	private CardsManager cardsManager;
	private int showingCard;
	public Sprite spNotSelected;
	private bool canNotShow;
	public List<Image> showing = new List<Image>();

	void Start ()
	{
		cardsManager = GameObject.Find ("CardsPanel").GetComponent<CardsManager> ();
		PlayerPrefs.SetInt ("CONTADOR", 0);
		canNotShow = false;
		showingCard = 0;
	}
	
	void Update ()
	{
		if(showingCard > 2)
		{
			for(int i = 1; i <= 20; i++)
			{
				if(showing[0].sprite.name == showing[1].sprite.name)
				{
					Debug.Log ("iguais");
				}
				cardsManager.imageObj[i].sprite = spNotSelected;
				PlayerPrefs.SetInt ("CONTADOR", 0);
				showing.Clear();
			}
		}
		Debug.Log (PlayerPrefs.GetInt ("CONTADOR"));
		Debug.Log (showingCard);
	}

	public void ShowImage()
	{
		gameObject.GetComponent<Image>().sprite = cardsManager.spriteSaved[int.Parse(gameObject.name)];
		showing.Add(gameObject.GetComponent<Image>());
		PlayerPrefs.SetInt("CONTADOR", PlayerPrefs.GetInt("CONTADOR") + 1);
		for(int i = 1; i <= 20; i++)
		{
			showingCard = PlayerPrefs.GetInt("CONTADOR");
			canNotShow = true;
		}
	}
}
