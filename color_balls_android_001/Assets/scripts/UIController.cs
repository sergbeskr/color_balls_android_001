using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class UIController : MonoBehaviour {

	private static UIController _instance;

	[SerializeField] 
	private Slider sliderHealth; 
	[SerializeField] 
	private Canvas gameCanvas;

	public delegate void OnChangeColorMethod (string btnColor);

	public static event OnChangeColorMethod OnChangeColor;

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
		gameCanvas.enabled = true;
	}
	
	// Update is called once per frame
	void Update () {
		sliderHealth.value = GameController.canonHealth;
		if (!GameController.alive) {
			gameCanvas.enabled = false;
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

}
