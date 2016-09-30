using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class Cards : MonoBehaviour
{
	private CardsManager cardsManager;

	void Start ()
	{
		cardsManager = GameObject.Find ("CardsPanel").GetComponent<CardsManager> ();
	}
	
	void Update ()
	{
       
	}

	public void ShowImage()
	{
        cardsManager.TurnCard(gameObject.GetComponent<Image>(), int.Parse(gameObject.name));
	}
}
