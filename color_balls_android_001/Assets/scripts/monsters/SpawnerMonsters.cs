using UnityEngine;
using System.Collections.Generic;
using System.Collections;

public class SpawnerMonsters : MonoBehaviour {

	[SerializeField]
	private GameObject monstersPref;

	public delegate void Spawn ();
	public static event Spawn OnSpawn;

	private bool stop = false;
	// Use this for initialization
	void Start () {
		GameController.OnStopSpawn += () => stop = true;
		InvokeRepeating("SpawningMonsters", 1f, 3f);
	}

	void Stop()
	{

	}

	void SpawningMonsters()
	{
		if (stop || !GameController.playerAlive) {
				CancelInvoke ("SpawningMonsters");
		}
			
		if (OnSpawn != null) {
			OnSpawn ();
		}

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
		monster.SetColor (GameController.colors[GameController.colorsStringArray [c]]);
			
	}

	void OnDestroy()
	{
		OnSpawn = null;
	}
}
