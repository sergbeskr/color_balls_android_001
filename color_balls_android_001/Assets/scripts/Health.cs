using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {

	public float maxHealthe = 100;
	private float currHealthe = 100;
	public Slider healthBar;

	// Use this for initialization
	void Start () {
		healthBar.maxValue = maxHealthe;
	}
	
	// Update is called once per frame
	void Update () {

		// death
		if (currHealthe <= 0) {
			currHealthe = 0;
			GameController.alive = false;
			Destroy (GameObject.FindGameObjectWithTag("monster"));
		}

	}

	void OnTriggerEnter(Collider collider)
	{

	}

}
