using UnityEngine;
using System.Collections;

public class AudioSettings : MonoBehaviour {

	void SetSoundVolumeInternal(float volume)
	{
		//_volumeSound = volume;
		SaveSettings();
		ApplySoundVolume();
	}

	//float GetSoundVolumeInternal()
	//{
	//	return; //_volumeSound;
	//}

	void SaveSettings()
	{
		//PlayerPrefs.SetFloat("SM_SoundVolume", _volumeSound);
	}

	void LoadSettings()
	{
		//_volumeSound = PlayerPrefs.GetFloat("SM_SoundVolume", 1);

		ApplySoundVolume();
	}

	void ApplySoundVolume()
	{//
		//foreach (AudioSource sound in _sounds)
		//{
			//sound.volume = _volumeSound * DefaultSoundVolume;
		//}
	}
}
