using UnityEngine;
using System.Collections;
using System;

public class AudioSettings : MonoBehaviour {

	public void SoundVolume(float volume)
	{
		AudioManager.SoundVolume(volume);
	}

	public void MusicVolume(float volume)
	{
		AudioManager.MusicVolume(volume);
	}

	public void ToggleMusicMuted(bool value)
	{
		AudioManager.MuteMusic(!value);
	}

	public void ToggleSoundMuted(bool value)
	{
		AudioManager.MuteSound(!value);
	}
}
