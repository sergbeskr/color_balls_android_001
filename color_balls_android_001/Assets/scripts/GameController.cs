using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour {

	public GameObject spawnerMonstersPref;
	public static float damage = 25;
	public static int number = 10;
	public static bool alive = true;
	public static float canonHealth = 100;

	// Use this for initialization
	void Start () {
		spawnerSpawn ();
		//////GameObject temp = new GameObject ("temp", new System.Type[]{typeof (CapsuleCollider)});// with params example


	}
	
	// Update is called once per frame
	void Update () {
	
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
