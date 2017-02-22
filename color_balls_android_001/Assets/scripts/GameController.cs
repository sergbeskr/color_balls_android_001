using UnityEngine;
using System.Collections.Generic;
using System.IO;

public class GameController : MonoBehaviour {

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
	public static LevelProps[] levelProps;

	private int startNumber;	
	private int damage;
	private int numberOfSpawners;
	private int killedMonsers = 0;
	private GameObject spawnerMonstersPref;	
	
	private string path;
	private string jsonString;

	public delegate void Win ();
	public static event Win OnWin;

	void Start () {
		Init();
		spawnerSpawn ();
		MonsterMovement.OnPlayerDamage += () => canonHealth -= damage;
	}

	void Update()
	{
		if (OnWin != null && deadMonsters == startNumber * numberOfSpawners) {
			OnWin ();
		}

	}

	void Init()
	{
		path = Application.streamingAssetsPath + "/LevelsProp.json";
		jsonString = File.ReadAllText(path);
		levelProps = JsonHelper.FromJson<LevelProps> (jsonString);

		int l = LevelProps.levelCurr - 1;
		canonHealth = levelProps[l].canonHealth;
		startNumber = levelProps[l].startNumberOfMonsters;
		maxMonsterHealth = levelProps[l].maxMonsterHealth;
		damage = levelProps[l].damage;
		spawnMonstersRadius = levelProps[l].spawnMonstersRadius;
		numberOfSpawners = levelProps [l].numberOfSpawners;
		
		playerAlive = true;
		deadMonsters = 0;
		
	}


	void spawnerSpawn()
	{
		float k = spawnMonstersRadius / 2;
		for (int i = 1; i <= numberOfSpawners;  i++) {
			Vector3 pos = new Vector3 (Random.Range (-20f - k, -50f + k), 3, Random.Range (20f + k, 50f - k));
			Instantiate (Resources.Load ("Prefabs/Spawner"), pos, Quaternion.identity);
		}
	}
		
	void OnDestroy()
	{
		OnWin = null;
	}
}
