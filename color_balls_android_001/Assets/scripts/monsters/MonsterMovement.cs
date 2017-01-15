using UnityEngine;
using System.Collections;

public class MonsterMovement : MonoBehaviour {

	private NavMeshAgent agent;
	private Transform player;

	// Use this for initialization
	void Start () {
		
		agent = GetComponent<NavMeshAgent> ();
		player = GameObject.Find ("Canon").transform;

	}
	
	// Update is called once per frame
	void Update () {
		
		agent.SetDestination (player.position);

	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Fence") {
			
			Destroy (gameObject);
			GameController.canonHealth -= GameController.damage; 

		}
	}
}
