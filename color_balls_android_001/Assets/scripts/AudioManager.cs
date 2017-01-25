using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AudioManager : MonoBehaviour {

	private static AudioManager _instance;

	string currentMusicName;

	private GameObject soundPrefab;
	//List<AudioClip> _sounds = new List<AudioClip>();

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

	}

	#endregion

	#region Music

	public void PlayMusicInternal(string musicName)
	{
		if (string.IsNullOrEmpty(musicName)) {
			Debug.Log("Music empty or null");
			return;
		}

		if (currentMusicName == musicName) {
			Debug.Log("Music already playing: " + musicName);
			return;
		}

		StopMusicInternal ();

		currentMusicName = musicName;

		AudioClip musicClip = LoadClip("Music/" + musicName);

		GameObject music = new GameObject("Music: " + musicName);
		AudioSource musicSource = music.AddComponent<AudioSource>();

		music.transform.SetParent(transform);

		musicSource.loop = true;
		musicSource.priority = 0;
		musicSource.ignoreListenerPause = true;
		musicSource.clip = musicClip;
		musicSource.Play();
	}

	void StopMusicInternal()
	{
		currentMusicName = "";
	}

	#endregion

	#region Sound

	public void PlaySoundInternal(string soundName, bool pausable)
	{
		if (string.IsNullOrEmpty(soundName)) {
			Debug.Log("Sound null or empty");
			return;
		}

		int sameCount = 0; // duplicates

		/*foreach (AudioClip audioClip in _sounds)
		{
			if (audioClip.name == soundName)
				sameCount++;
		}

		if (sameCount > 4)
		{
			Debug.Log("Too much duplicates for sound: " + soundName);
			return;
		}

		if (_sounds.Count > 6) {
			Debug.Log("Too much sounds");
			return;
		}*/
		Debug.Log ("click");

		StartCoroutine(PlaySoundInternalSoon(soundName, pausable));
	}


	IEnumerator PlaySoundInternalSoon(string soundName, bool pausable)
	{		
		ResourceRequest request = LoadClipAsync("Sounds/" + soundName);

		while (!request.isDone)
		{
			yield return null;
		}
		AudioClip soundClip = (AudioClip)request.asset;

		if (soundClip == null)
		{
			Debug.Log("Sound not loaded: " + soundName);
		}


		//soundPrefab = Resources.Load ("AudioManager/sound") as GameObject;
		//GameObject soundGObj = Instantiate(soundPrefab) as GameObject;
		GameObject soundGObj = new GameObject("Sound:" + soundName);
		AudioSource soundSource = soundGObj.AddComponent<AudioSource>();
		soundGObj.transform.parent = transform;

		//AudioSource soundSource = soundGObj.GetComponent<AudioSource>();

		//soundSource.volume
		soundSource.playOnAwake = false;
		soundSource.loop = false;
		soundSource.clip = soundClip;
		soundSource.Play();
		soundSource.ignoreListenerPause = !pausable;
		Destroy (soundGObj, soundSource.clip.length);
		//_sounds.Add(soundSource.clip);
	}

	#endregion

	AudioClip LoadClip(string name)
	{
		string path = "AudioManager/" + name;
		AudioClip clip = Resources.Load<AudioClip>(path);
		return clip;
	}

	ResourceRequest LoadClipAsync(string name)
	{
		string path = "AudioManager/" + name;
		Debug.Log ("Loading");
		return Resources.LoadAsync<AudioClip>(path);
	}

	public static void Pause()
	{
		AudioListener.pause = true;
	}

	public static void UnPause()
	{
		AudioListener.pause = false;
	}

	/*void Update()
	{
		// Destory only one sound per frame
		AudioClip soundToDelete = null;

		foreach (AudioClip sound in _sounds) {
			if (IsSoundFinished (sound)) {
				soundToDelete = sound;
				break;
			}
		}

		if (soundToDelete != null) {
			soundToDelete.IsValid = false;
			_sounds.Remove (soundToDelete);
			Destroy (soundToDelete.Source.gameObject);
		}
	}*/
}
