using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;

public class CardsManager : MonoBehaviour
{
	private List<Image> selectedCards = new List<Image>();
	private List<int> nameEquals = new List<int>();
	private int randomCard, counterToTurn, count, rightCards, rightScore;
	private bool canCount, canShow, firstClick, soundPaused;
	public Sprite spNotSelected, withSound, withoutSound;
	public Image[] imageObj;
	public List<Sprite> imageSprite = new List<Sprite>(20);
	public List<Sprite> spriteSaved = new List<Sprite>();
	public Text scoreTxt, pausedText;
	public bool setHighscore, paused;
	private static float points;
	public Button musicManager;
	private AudioSource audio;
	
	void Start ()
	{
		Time.timeScale = 1;
		pausedText.enabled = false;
		canShow = true;
		audio = Object.FindObjectOfType <AudioSource>() as AudioSource;
		imageObj = gameObject.GetComponentsInChildren<Image>();
		for (int i = 1; i <= 20; i++)
		{
			randomCard = Random.Range(0, imageSprite.Count);
			spriteSaved.Add(imageSprite[randomCard]);
			imageSprite.Remove(imageSprite[randomCard]);
		}
		rightCards = 0;
		points = 0;
		rightScore = 0;
		if (!PlayerPrefs.HasKey("SCORE"))
			PlayerPrefs.SetInt("SCORE", 0);
	}
	
	void Update ()
	{
		if(!paused)
		{
			if (canCount)
			{
				counterToTurn++;
				if (counterToTurn >= 100)
				{
					canCount = false;
					selectedCards[0].sprite = spNotSelected;
					selectedCards[1].sprite = spNotSelected;
					selectedCards.Clear();
					counterToTurn = 0;
					canShow = true;
				}
			}
			if (rightCards == 10)
			{
				SetHighScore();
				Application.LoadLevel ("Highscore");
			}
			points += Time.deltaTime;
			rightScore = (int)points;
			scoreTxt.text = "SCORE: " + rightScore.ToString();
		}

		if (soundPaused)
		{
			audio.mute = true;
			musicManager.GetComponent<Image> ().sprite = withoutSound;
		}
		else if (!soundPaused)
		{
			audio.mute = false;
			musicManager.GetComponent<Image> ().sprite = withSound;
		}
		
		if (paused)
		{
			Time.timeScale = 0;
			pausedText.enabled = true;
		}
		else if (!paused)
		{
			Time.timeScale = 1;
			pausedText.enabled = false;
		}
	}
	
	private void CompareImages(Image img, Image img1)
	{
		if(!paused)
		{
			if (img.sprite.name == img1.sprite.name)
			{
				selectedCards.Clear();
				canShow = true;
				rightCards += 1;
			}
			else canCount = true;
		}
	}
	
	public void TurnCard(Image image, int name)
	{
		if(!paused)
		{
			if (count < 2 && canShow)
			{
				if (count == 0)
				{
					nameEquals.Add(name);
					image.sprite = spriteSaved[name];
					selectedCards.Add(image);
					count++;
				}
				else if (count == 1) 
				{
					if (name != nameEquals[0])
					{
						image.sprite = spriteSaved[name];
						selectedCards.Add(image);
						count++;
						nameEquals.Clear();
					}
				}
				
				if (count == 2)
				{
					canShow = false;
					count = 0;
					CompareImages(selectedCards[0], selectedCards[1]);
				}
			}
		}
	}
	
	private void SetHighScore()
	{
		PlayerPrefs.SetInt("SCORE", rightScore);
		setHighscore = true;
	}
	
	public void ChangeScene(int i)
	{
		Application.LoadLevel (i);
	}

	public void Reload()
	{
		Application.LoadLevel(Application.loadedLevel);
	}
	
	public void PauseGame()
	{
		paused = !paused;
	}
	
	public void Sound()
	{
		soundPaused = !soundPaused;
	}
}
