using UnityEngine;
using System.Collections;
using System.Collections.Generic;

using UnityEngine.Audio;

public class AudioManager : MonoBehaviour {

	private static AudioManager _instance;

	#region Singleton

	private AudioManager()
	{

	}

	public static AudioManager Instance
	{
		get {
			if (_instance == null) {
				_instance = new AudioManager ();
			}

			return new GameObject ("(singleton)AudioManager").AddComponent<AudioManager> ();
		}
	}

	void Awake()
	{
		if (_instance != null)
		{
			Destroy(gameObject);
			return;
		}

		_instance = this;
		DontDestroyOnLoad(gameObject);

		musicVolume = 1;
		soundVolume = 1;
	}

	#endregion

	public float fadeSpeed = 3; 

	private static AudioSource last, current;
	private static float musicVolume, soundVolume;
	private static bool muteMusic, muteSound;

	public static void SoundVolume(float volume)
	{
		soundVolume = volume;
	}

	public static void MusicVolume(float volume)
	{
		musicVolume = volume;
		if(current) current.volume = volume;
	}

	public static void MuteSound(bool value)
	{
		muteSound = value;
	}

	public static void MuteMusic(bool value)
	{
		muteMusic = value;
		if(current) current.mute = value;
	}


	void PlaySoundInternal(string soundName)
	{
		if(string.IsNullOrEmpty(soundName))
		{
			Debug.Log("Sound empty or null");
			return;
		}

		StartCoroutine(GetSound(soundName));
	}

	public static void PlaySound(string name)
	{
		_instance.PlaySoundInternal(name);
	}

	void PlayMusicInternal(string musicName)
	{
		if(string.IsNullOrEmpty(musicName))
		{
			Debug.Log("Music empty or null");
			return;
		}

		StartCoroutine(GetMusic(musicName));
	}

	public static void PlayMusic(string name)
	{
		_instance.PlayMusicInternal(name);
	}

	void LateUpdate()
	{
		Fader();
	}

	void Fader()
	{
		if(last == null) return;

		last.volume = Mathf.Lerp(last.volume, 0, fadeSpeed * Time.deltaTime);
		current.volume = Mathf.Lerp(current.volume, musicVolume, fadeSpeed * Time.deltaTime);

		if(last.volume < 0.05f)
		{
			last.volume = 0;
			Destroy(last.gameObject);
		}
	}

	IEnumerator GetMusic(string musicName)
	{
		ResourceRequest request = LoadAsync("Music/" + musicName);

		while(!request.isDone)
		{
			yield return null;
		}

		AudioClip clip = (AudioClip)request.asset;

		if(clip == null)
		{
			Debug.Log("Music not loaded: " + musicName);
			return false;
		}

		last = current;

		GameObject obj = new GameObject("Music: " + musicName);
		AudioSource au = obj.AddComponent<AudioSource>();
		obj.transform.parent = transform;
		au.playOnAwake = false;
		au.loop = true;
		au.volume = (last == null) ? musicVolume : 0;
		au.mute = muteMusic;
		au.clip = clip;
		au.Play();
		current = au;
	}

	IEnumerator GetSound(string soundName)
	{
		ResourceRequest request = LoadAsync("Sounds/" + soundName);

		while(!request.isDone)
		{
			yield return null;
		}

		AudioClip clip = (AudioClip)request.asset;

		if(clip == null)
		{
			Debug.Log("Sound not loaded: " + soundName);
			return false;
		}

		GameObject obj = new GameObject("Sound: " + soundName);
		AudioSource au = obj.AddComponent<AudioSource>();
		obj.transform.parent = transform;
		au.playOnAwake = false;
		au.loop = false;
		au.volume = soundVolume;
		au.mute = muteSound;
		au.clip = clip;
		au.Play();
		Destroy(obj, clip.length);
	}

	ResourceRequest LoadAsync(string name)
	{
		string path = "AudioManager/" + name;
		return Resources.LoadAsync<AudioClip>(path);
	}
}
