using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardsManager : MonoBehaviour
{
	public Image[] imageObj;
	public List<Sprite> imageSprite = new List<Sprite>(20);
	public List<Sprite> spriteSaved = new List<Sprite>();
	private int randomCard;

	void Start ()
	{
		imageObj = gameObject.GetComponentsInChildren<Image>();
		for (int i = 1; i <= 20; i++)
		{
			randomCard = Random.Range(0, imageSprite.Count);
			spriteSaved.Add(imageSprite[randomCard]);
			imageSprite.Remove(imageSprite[randomCard]);
		}
	}

	void Update ()
	{

	}
}
