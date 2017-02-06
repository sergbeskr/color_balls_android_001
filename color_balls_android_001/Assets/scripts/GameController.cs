using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	[SerializeField]
	private GameObject spawnerMonstersPref;
	[SerializeField]
	private Camera camera1, camera2;

	public static float damage;
	public static bool playerAlive; 
	public static float canonHealth;
	public static float maxMonsterHealth;
	public static float spawnMonstersRadius;
	public static int killedMonsters;
	public static bool win;

	public static Dictionary<string, Color> colors = new Dictionary<string, Color> () {
		{"red", Color.red},
		{"yellow", Color.yellow},
		{"green", Color.green},
		{"blue", Color.blue},
		{"magenta", Color.magenta},
	};
		
	private int curr_number;
	private int startNumber;

	public delegate void StopSpawn ();
	public static event StopSpawn OnStopSpawn;

	void Start () {
		Init ();
		if (PlayerPrefs.HasKey ("Camera")) {
			int c = PlayerPrefs.GetInt ("Camera");
			if (c == 1) {
				camera2.gameObject.SetActive (false);
				camera1.gameObject.SetActive (true);
			} else {
				camera1.gameObject.SetActive (false);
				camera2.gameObject.SetActive (true);
			}
		}

		spawnerSpawn ();
		SpawnerMonsters.OnSpawn += () => curr_number--;
	}

	void Update()
	{
		if (playerAlive && killedMonsters == startNumber) {
			win = true;
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
		killedMonsters = 0;
		win = false;
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
