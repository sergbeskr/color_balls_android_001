using UnityEngine;
using System.Collections;

public class SpawnerMonsters : MonoBehaviour {

	public GameObject monstersPref;
	private float spawnRadius = 5f;

	// Use this for initialization
	void Start () {
		InvokeRepeating("spawningMonsters", 1f, 3f);
	}

	void spawningMonsters()
	{
		if (GameController.number == 0 || !GameController.alive) {
			CancelInvoke ("spawningMonsters");
		}

		Vector3 pos = new Vector3 (Random.Range (gameObject.transform.position.x - spawnRadius, gameObject.transform.position.x + spawnRadius), 3, Random.Range (gameObject.transform.position.z - spawnRadius, gameObject.transform.position.z + spawnRadius));
		Instantiate (monstersPref, pos, Quaternion.identity);
		GameController.number--;
	}
}
