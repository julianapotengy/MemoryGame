using UnityEngine;
using System.Collections;

public class SongsManager : MonoBehaviour
{
	public AudioClip[] randomSongs = new AudioClip[10];
	private AudioSource audio;
	private static SongsManager instance = null;
	public static SongsManager Instance
	{
		get { return instance; }
	}
	
	void Awake()
	{
		if (instance != null && instance != this)
		{
			Destroy(this.gameObject);
			return;
		} else instance = this;
		DontDestroyOnLoad(this.gameObject);
	}
	
	void Start ()
	{
		audio = GetComponent<AudioSource> ();
		if (!audio.playOnAwake)
		{
			audio.clip = randomSongs[Random.Range(0, randomSongs.Length)];
			audio.Play();
		}
	}
	
	void Update ()
	{
		if (!audio.isPlaying)
		{
			audio.clip = randomSongs[Random.Range(0, randomSongs.Length)];
			audio.Play();
		}
	}
}
