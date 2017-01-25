using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public GameObject spawnerMonstersPref;
	public static float damage;
	public static int number;
	public static bool playerAlive; 
	public static float canonHealth;
	public static float maxMonsterHealth;
	public static float spawnMonstersRadius;

	public static Dictionary<string, Color> colors = new Dictionary<string, Color> () {
		{"red", Color.red},
		{"yellow", Color.yellow},
		{"green", Color.green},
		{"blue", Color.blue},
		{"magenta", Color.magenta},
	};
		

	void Start () {
		Init ();
		spawnerSpawn ();
	}

	void Init()
	{
		damage = 25;
		number = 10;
		playerAlive = true;
		canonHealth = 100;
		maxMonsterHealth = 50;
		spawnMonstersRadius = 5;
	}

	void spawnerSpawn()
	{
		//for (int i = 1; i <= number;  i++) {
		//	Vector3 pos = new Vector3 (Random.Range (0f, 150f), 3, Random.Range (0f, 150f));
		Vector3 pos = new Vector3 (-20f, 3, 20f);
		Instantiate (spawnerMonstersPref, pos, Quaternion.identity);
		//}
	}
		
}
