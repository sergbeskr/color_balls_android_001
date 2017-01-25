using UnityEngine;
using System.Collections.Generic;

public class GameController : MonoBehaviour {

	public GameObject spawnerMonstersPref;
	public static float damage = 25;
	public static int number = 10;
	public static bool playerAlive = true; 
	public static float canonHealth = 100;
	public static float maxMonsterHealth = 50;
	public static float spawnMonstersRadius = 5;

	public static Dictionary<string, Color> colors = new Dictionary<string, Color> () {
		{"red", Color.red},
		{"yellow", Color.yellow},
		{"green", Color.green},
		{"blue", Color.blue},
		{"magenta", Color.magenta},
	};

	//private static GameController _instance;

/*	#region Singleton

	private GameController()
	{
	}

	public static GameController Instance
	{
		get {
			if (_instance == null) {
				_instance = new GameController ();
			}

			return new GameObject ("(singleton)GameController").AddComponent<GameController> ();
		}
	}*/

	void Awake()
	{
		/*if (_instance != null)
		{
			Destroy(gameObject);
			return;
		}

		_instance = this;*/
		DontDestroyOnLoad(gameObject);
	}

	//#endregion

	void Start () {
			spawnerSpawn ();
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
