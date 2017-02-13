using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	private GameObject spawnerMonstersPref;

	public static byte level = 1;
	public static bool playerAlive; 
	public static float canonHealth;
	public static float maxMonsterHealth;
	public static float spawnMonstersRadius;
	public static int deadMonsters;
	public static string[] colorsStringArray = { "red", "yellow", "green", "blue", "magenta" };
	public static Dictionary<string, Color> colors = new Dictionary<string, Color> () {
		{"red", Color.red},
		{"yellow", Color.yellow},
		{"green", Color.green},
		{"blue", Color.blue},
		{"magenta", Color.magenta},
	};



	private int curr_number;
	private int startNumber;	
	private int damage;

	public delegate void StopSpawn ();
	public static event StopSpawn OnStopSpawn;

	public delegate void Win ();
	public static event Win OnWin;

	void Start () {
		Init();
		spawnerSpawn ();
		SpawnerMonsters.OnSpawn += () => curr_number--;
		MonsterMovement.OnPlayerDamage += () => canonHealth -= damage;
	
	}

	void Update()
	{
		if (OnWin != null && deadMonsters == startNumber) {
			OnWin ();
		}

		if (OnStopSpawn != null && curr_number == 1) {
			OnStopSpawn ();
		}

	}

	void Init()
	{
		damage = 25;
		startNumber = 10;
		curr_number = startNumber;
		playerAlive = true;
		canonHealth = 100;
		maxMonsterHealth = 50;
		spawnMonstersRadius = 5;
		deadMonsters = 0;
	}


	void spawnerSpawn()
	{
		Debug.Log ("spawner");

		//for (int i = 1; i <= number;  i++) {
		//	Vector3 pos = new Vector3 (Random.Range (0f, 150f), 3, Random.Range (0f, 150f));
		Vector3 pos = new Vector3 (-20f, 3, 20f);
		Instantiate (Resources.Load ("Prefabs/Spawner"), pos, Quaternion.identity);
		//}
	}
		
		
}
