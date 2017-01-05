using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine.SceneManagement;

public class UIController : MonoBehaviour {

	[SerializeField] 
	private Slider sliderHealth; 
	[SerializeField] 
	private Canvas gameCanvas;
	[SerializeField]
	private List<Button> buttons = new List<Button>();

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
		foreach (Button b in buttons) {

		}
	}

}
