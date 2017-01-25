using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	private static UIController _instance;

	[SerializeField] 
	private Slider sliderHealth; 
	[SerializeField] 
	private Canvas gameCanvas;

	private Transform gameUI;
	private Transform gamePause;

	public delegate void OnChangeColorMethod (string btnColor);

	public static event OnChangeColorMethod OnChangeColor;

	public static bool isPause = false;
	public static bool isStarted = false;


	void Awake()
	{
		DontDestroyOnLoad(gameObject);
	}


	// Use this for initialization
	void Start () {
		AudioManager.Instance.PlayMusicInternal ("Startsong");

		gamePause = gameCanvas.transform.GetChild (0);
		gameUI = gameCanvas.transform.GetChild (3);

	}
	
	// Update is called once per frame
	void Update () {
		sliderHealth.value = GameController.canonHealth;
		if (!GameController.playerAlive) {
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
		gameCanvas.transform.GetChild (4).gameObject.SetActive (false);// panel start dont active
		gameUI.gameObject.SetActive (true);
		AudioManager.Instance.PlayMusicInternal ("Level1");
		isStarted = true;
	}

	public void OnPauseClick()
	{
		isPause = !isPause;
		if (isPause) {
			Time.timeScale = 0;
			gamePause.gameObject.SetActive (true);
			gameUI.gameObject.SetActive (false);
		} else {
			Time.timeScale = 1;
			gamePause.gameObject.SetActive (false);
			gameUI.gameObject.SetActive (true);
		}
	}

	public void OnExitClick()
	{
		Application.Quit ();
	}
		
}
