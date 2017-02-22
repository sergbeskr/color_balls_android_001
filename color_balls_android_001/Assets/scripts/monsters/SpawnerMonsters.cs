using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SpawnerMonsters : MonoBehaviour {

	[SerializeField]
	private GameObject monstersPref;

	//public delegate void Spawn ();
	//public static event Spawn OnSpawn;

	private bool stop = false;
	private int currNum = 0;
	// Use this for initialization
	void Start () {
		float timeSpawn = GameController.levelProps [LevelProps.levelCurr - 1].timeOfSpawn;

		//GameController.OnStopSpawn += () => stop = true;
		InvokeRepeating("SpawningMonsters", 1f, timeSpawn);
	}

	void SpawningMonsters()
	{
		if (GameController.levelProps[LevelProps.levelCurr - 1].startNumberOfMonsters == currNum || !GameController.playerAlive) {
			CancelInvoke ("SpawningMonsters");
		} else {
			//if (OnSpawn != null) {
			//	OnSpawn ();
			//}

			// Position spawn
			Vector3 pos = new Vector3 (Random.Range (gameObject.transform.position.x - GameController.spawnMonstersRadius, 
				             gameObject.transform.position.x + GameController.spawnMonstersRadius), // random x
				             3, 
				             Random.Range (gameObject.transform.position.z - GameController.spawnMonstersRadius, // random y
					             gameObject.transform.position.z + GameController.spawnMonstersRadius));
		
			GameObject go = Instantiate (monstersPref, pos, Quaternion.identity) as GameObject;

			//Random color
			IMonster monster = go.GetComponent<IMonster> ();
			int c = Random.Range (0, 5);
			monster.SetColor (GameController.colors [GameController.colorsStringArray [c]]);
			currNum++;
		}
	}

	//void OnDestroy()
	//{
	//	OnSpawn = null;
	//}
}
