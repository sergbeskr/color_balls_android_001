using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	[SerializeField] 
	private Slider sliderHealth; 
	[SerializeField] 
	private Canvas gameCanvas;

	[SerializeField]
	private GameObject gameUI;
	[SerializeField]
	private GameObject gamePause;
	[SerializeField]
	private GameObject audioSettings;
	[SerializeField]
	private GameObject gameOver;
	[SerializeField]
	private GameObject gameStart;

	public delegate void OnChangeColorMethod (string btnColor);

	public static event OnChangeColorMethod OnChangeColor;

	public static bool isPause = false;
	public static bool isStarted = false;

	// Use this for initialization
	void Start () {
		AudioManager.PlayMusic ("Startsong");
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

	public void OnStartGameClick()
	{
		gameStart.SetActive (false);// panel start dont active
		gameUI.SetActive (true);
		AudioManager.PlayMusic("Level1");
		isStarted = true;
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
	}

	public void OnRestart()
	{
		int scene = SceneManager.GetActiveScene().buildIndex;
		SceneManager.LoadScene(scene, LoadSceneMode.Single);
	}
		
}
