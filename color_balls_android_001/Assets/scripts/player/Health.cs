using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	
	void Update () {

		// death
		if (GameController.canonHealth <= 0) {
			GameController.canonHealth = 0;
			GameController.playerAlive = false;
		}

	}

}
