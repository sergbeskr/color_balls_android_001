using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Health : MonoBehaviour {
	
	void Update () {

		// death
		if (GameController.Instance.canonHealth <= 0) {
			GameController.Instance.canonHealth = 0;
			GameController.Instance.playerAlive = false;
		}

	}

}
