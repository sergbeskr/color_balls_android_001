using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;
using System;

public class UIController : MonoBehaviour {

	[SerializeField] 
	private Slider sliderHealth, musicVolumeSlider, soundVolumeSlider; 

	[SerializeField]
	private GameObject gameOver, audioSettings, gamePause, gameUI;

	[SerializeField]
	private Toggle muteMusic, muteSounds;

	public delegate void OnChangeColorMethod (string btnColor);

	public static event OnChangeColorMethod OnChangeColor;

	public static bool isPause = false;
	public static bool isStarted = false;

	// Use this for initialization
	void Start () {
		AudioManager.PlayMusic("Level1");
	}
	
	// Update is called once per frame
	void Update () {
		sliderHealth.value = GameController.canonHealth;
		if (!GameController.playerAlive) {
			gameUI.SetActive (false);
			gameOver.SetActive (true);
		}
	}

	public void OnClikcColorButton()
	{
		Debug.Log ("Click");
		string btnColorName = EventSystem.current.currentSelectedGameObject.name;
		if (OnChangeColor != null) {
			OnChangeColor (btnColorName);
		}
	}

	public void OnPauseClick()
	{
		isPause = !isPause;
		if (isPause) {
			Time.timeScale = 0;
			gamePause.SetActive (true);
			gameUI.SetActive (false);
		} else {
			Time.timeScale = 1;
			gamePause.SetActive (false);
			gameUI.SetActive (true);
		}
	}

	public void OnExitClick()
	{
		Application.Quit ();
	}

	public void OnAudioSettingsButton()
	{
		gamePause.SetActive (false);
		audioSettings.SetActive (true);

		if (PlayerPrefs.HasKey ("MusicVolume")) {
			musicVolumeSlider.value = PlayerPrefs.GetFloat ("MusicVolume");
		}
		if (PlayerPrefs.HasKey ("SoundVolume")) {
			soundVolumeSlider.value = PlayerPrefs.GetFloat ("SoundVolume");
		}
		if (PlayerPrefs.HasKey ("MusicMute")) {
			muteMusic.isOn = !Convert.ToBoolean (PlayerPrefs.GetInt ("MusicMute"));
		}
		if (PlayerPrefs.HasKey ("SoundsMute")) {
			muteSounds.isOn = !Convert.ToBoolean (PlayerPrefs.GetInt ("SoundsMute"));
		}
	}

	public void OnRestart()
	{
		SceneManager.LoadScene ("scene_001");
	}
		
	public void OnBackToMenu()
	{
		EventSystem.current.currentSelectedGameObject.transform.parent.gameObject.SetActive (false);// set current panel false
		gamePause.SetActive(true);
	}
		
}
