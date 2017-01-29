using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;
using System;


public class StartScreen : MonoBehaviour {

	void Start()
	{
		LoadSettings ();
		AudioManager.PlayMusic ("Startsong");
	}

	public void OnStart()
	{
		SceneManager.LoadScene("Scene_001");
	}

	void LoadSettings()
	{
		if (PlayerPrefs.HasKey ("MusicVolume")) {
			AudioManager.MusicVolume(PlayerPrefs.GetFloat ("MusicVolume"));
		}
		if (PlayerPrefs.HasKey ("SoundVolume")) {
			AudioManager.SoundVolume(PlayerPrefs.GetFloat("SoundVolume"));
		}
		if (PlayerPrefs.HasKey ("MusicMute")) {
			AudioManager.MuteMusic (Convert.ToBoolean(PlayerPrefs.GetInt ("MusicMute")));
		}
		if (PlayerPrefs.HasKey ("SoundsMute")) {
			AudioManager.MuteSound (Convert.ToBoolean(PlayerPrefs.GetInt ("SoundsMute")));
		}
	}
}
