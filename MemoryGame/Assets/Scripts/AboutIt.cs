using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class AboutIt : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
	void Start ()
	{
	
	}

	void Update ()
	{
	
	}

	public void OnPointerEnter(PointerEventData eventData)
	{

	}
	
	public void OnPointerExit (PointerEventData eventData) 
	{

	}

	public void ChangeScene(int i)
	{
		Application.LoadLevel (i);
	}
}
