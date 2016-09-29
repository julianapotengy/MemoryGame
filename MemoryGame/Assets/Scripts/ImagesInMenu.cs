using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class ImagesInMenu : MonoBehaviour
{
	public Image[] imageObj;
	public List<Sprite> imageSpriteList = new List<Sprite>(10);
	private int randomSprite;
	private int randomImage;
	private float timer;

	void Start ()
	{
		imageObj = gameObject.GetComponentsInChildren<Image>();
		timer = 0;
		for (int i = 0; i < 18; i++)
		{
			randomSprite = Random.Range(0, imageSpriteList.Count);
			imageObj[i].sprite = imageSpriteList[randomSprite];
		}
	}

	void Update ()
	{
		timer += Time.deltaTime;
		if(timer >= 2)
		{
			for (int i = 0; i < 18; i++)
			{
				randomSprite = Random.Range(0, imageSpriteList.Count);
				randomImage = Random.Range(0, imageObj.Length);
				imageObj[randomImage].sprite = imageSpriteList[randomSprite];
			}
			timer = 0;
		}
	}

	public void ChangeScene(int i)
	{
		Application.LoadLevel (i);
	}

	public void QuitGame()
	{
		Application.Quit ();
	}
}
