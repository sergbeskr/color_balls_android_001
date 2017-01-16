using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	
	// Use this for initialization
	void Start () {
	}
	
	// Update is called once per frame
	void Update () {

		// death
		if (GameController.canonHealth <= 0) {
			GameController.canonHealth = 0;
			GameController.alive = false;
		}

	}

}
