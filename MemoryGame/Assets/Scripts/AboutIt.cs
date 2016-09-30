using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AboutIt : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	public GameObject[] showSinopse;

	void Start ()
	{
		showSinopse = GameObject.FindGameObjectsWithTag (gameObject.name + "Panel");
		foreach(GameObject g in showSinopse)
		{
			g.SetActive(false);
		}
	}

	public void OnPointerEnter(PointerEventData eventData)
	{
		foreach(GameObject g in showSinopse)
		{
			g.SetActive(true);
		}
	}
	
	public void OnPointerExit (PointerEventData eventData) 
	{
		foreach(GameObject g in showSinopse)
		{
			g.SetActive(false);
		}
	}

	public void ChangeScene(int i)
	{
		Application.LoadLevel (i);
	}
}
