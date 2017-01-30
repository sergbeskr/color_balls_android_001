using UnityEngine;
using System.Collections;
using System;

public class SaveAudioSettings : MonoBehaviour {

	public void Save()
	{
		PlayerPrefs.SetFloat ("MusicVolume", AudioManager.musicVolume);
		PlayerPrefs.SetFloat ("SoundVolume", AudioManager.soundVolume);
		PlayerPrefs.SetInt ("MusicMute", Convert.ToInt32(AudioManager.muteMusic));
		PlayerPrefs.SetInt ("SoundsMute", Convert.ToInt32(AudioManager.muteSound));
		PlayerPrefs.Save ();
	}
}
