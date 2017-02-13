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
	private GameObject gameOver, audioSettings, gamePause, gameUI, videoSettings, win, gameController;

	[SerializeField]
	private Toggle muteMusic, muteSounds;

	[SerializeField]
	private GameObject[] colorButtons;

	[SerializeField]
	private Text killedText;

	[SerializeField]
	private Camera camera1, camera2;

	public delegate void ChangeColorMethod (string btnColor);

	public static event ChangeColorMethod OnChangeColor;

	public static bool isPause;
	public static bool isStarted;


	// Use this for initialization
	void Start () {
		int k;
		isPause = false;
		isStarted = false;
		LoadCameraSetings ();
		AudioManager.PlayMusic("Level1");

		GameController.OnWin += Win;

		k = 0;

		Monster.OnKill += () => {
			k++;
			killedText.text = k.ToString();
		};
			
	}
	
	// Update is called once per frame
	void Update () {

		sliderHealth.value = GameController.canonHealth;

		if (!GameController.playerAlive) {
			gameUI.SetActive (false);
			gameOver.SetActive (true);
		}

		OnKeyChangeColor ();
	}

	public void OnClikcColorButton()
	{
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

	public void OnVideoSettings()
	{
		gamePause.SetActive (false);
		videoSettings.SetActive (true);
	}

	void OnKeyChangeColor()
	{
		// on click key number, temp
		if (OnChangeColor != null) {
			for (int i = 0; i < 5; i++) {
				if (Input.GetKey ((i+1).ToString ())) {
					OnChangeColor (GameController.colorsStringArray [i]);
				}
			}
		}
	}

	public void OnNextLevelButton()
	{
		SceneManager.LoadScene ("scene_001");
	}

	void Win()
	{
		gameUI.SetActive (false);
		win.SetActive (true);
	}

	void LoadCameraSetings()
	{
		Debug.Log ("Load ");
		if (PlayerPrefs.HasKey ("Camera")) {
			int c = PlayerPrefs.GetInt ("Camera");
			if (c == 1) {
				Debug.Log ("c " + c);
				camera2.gameObject.SetActive (false);
				camera1.gameObject.SetActive (true);
			} else {
				Debug.Log ("c " + c);
				camera1.gameObject.SetActive (false);
				camera2.gameObject.SetActive (true);
			}
		}
	}

	void OnDestroy()
	{
		GameController.OnWin -= Win;
	}
}
