using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SpawnerMonsters : MonoBehaviour {

	[SerializeField]
	private GameObject monstersPref;

	private string[] colors = { "red", "yellow", "green", "blue", "magenta" };

	// Use this for initialization
	void Start () {
		InvokeRepeating("SpawningMonsters", 1f, 3f);
	}

	void SpawningMonsters()
	{
		if (GameController.Instance.number == 0 || !GameController.Instance.playerAlive) {
			CancelInvoke ("spawningMonsters");
		}

		// Position spawn
		Vector3 pos = new Vector3 (Random.Range (gameObject.transform.position.x - GameController.Instance.spawnMonstersRadius, 
												 gameObject.transform.position.x + GameController.Instance.spawnMonstersRadius), // random x
												 3, 
												 Random.Range (gameObject.transform.position.z - GameController.Instance.spawnMonstersRadius, // random y
												 gameObject.transform.position.z + GameController.Instance.spawnMonstersRadius));
		
		GameObject go = Instantiate (monstersPref, pos, Quaternion.identity) as GameObject;

		//Random color
		IMonster monster = go.GetComponent<IMonster> ();
		int c = Random.Range (0, 5);
		monster.SetColor (GameController.Instance.colors[colors[c]]);

		GameController.Instance.number--;

	}
}
