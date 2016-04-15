using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class SoundManager : Singleton<SoundManager> 
{
	private AudioSource effectSource;
	private AudioSource musicSource;

	private AudioClip musicClip;
	private Dictionary<string, AudioClip> effectClips;

	protected SoundManager() {}

	void Awake()
	{
		DontDestroyOnLoad(this);
	}

	void Start()
	{
		//Find source
		musicSource = gameObject.AddComponent<AudioSource>();
		effectSource = gameObject.AddComponent<AudioSource>();

		//init sound
		musicClip = Resources.Load("Sound/music") as AudioClip;
		musicSource.clip = musicClip;
		musicSource.loop = true;
		musicSource.volume = 0.7f;
		musicSource.Play();

			
		//init clips
		effectClips = new Dictionary<string, AudioClip>();
		effectClips.Add("pop", Resources.Load("Sound/pop") as AudioClip);
		effectClips.Add("jump", Resources.Load("Sound/jump") as AudioClip);
		effectClips.Add("bad", Resources.Load("Sound/bad") as AudioClip);
	}

	public void PlayEffect(string name)
	{
		effectSource.PlayOneShot(effectClips[name]);
	}
}
