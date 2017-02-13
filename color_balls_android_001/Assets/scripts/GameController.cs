using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class GameController : MonoBehaviour {


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
	private GameObject spawnerMonstersPref;
	
	private string path;
	private string jsonString;

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
		/*damage = 25;
		startNumber = 10;
		curr_number = startNumber;
		playerAlive = true;
		canonHealth = 100;
		maxMonsterHealth = 50;
		spawnMonstersRadius = 5;
		deadMonsters = 0;*/
		path = "LevelsProp.json";
		jsonString = File.ReadAllText(path);
		LevelsProps levelsProps = JsonUtility.FromJson<LevelsProps>(jsonString);
		
		canonHealth = levelsProps.levels[level].canonHealth;
		//startNumber = levels[level].startNumberOfMonsters;
		//maxMonsterHealth = levels[level].maxMonsterHealth;
		//damage = levels[level].damage;
		//spawnMonstersRadius = levels[level].spawnMonstersRadius;
		
		playerAlive = true;
		deadMonsters = 0;
		curr_number = startNumber;
		
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
