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

	public bool isPause = false;

	#region Singleton

	private UIController()
	{

	}

	public static UIController Instance
	{
		get {
			if (_instance == null) {
				_instance = new UIController ();
			}

			return new GameObject ("(singleton)UIController").AddComponent<UIController> ();
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

	// Use this for initialization
	void Start () {
		AudioManager.Instance.PlayMusicInternal ("Startsong");

		gamePause = gameCanvas.transform.GetChild (0);
		gameUI = gameCanvas.transform.GetChild (3);

	}
	
	// Update is called once per frame
	void Update () {
		sliderHealth.value = GameController.Instance.canonHealth;
		if (!GameController.Instance.playerAlive) {
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
	}

	public void OnPauseClick()
	{
		isPause = !isPause;
		if (isPause) {
			gamePause.gameObject.SetActive (true);
		} else {
			gamePause.gameObject.SetActive (false);
		}
	}

	public void OnExitClick()
	{
		Application.Quit ();
	}
		
}
