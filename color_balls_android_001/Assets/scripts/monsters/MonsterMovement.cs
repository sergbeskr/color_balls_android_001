using UnityEngine;
using System.Collections;

public class MonsterMovement : MonoBehaviour {

	private NavMeshAgent agent;

	[SerializeField]
	private Transform player;

	// Use this for initialization
	void Start () {
		
		agent = GetComponent<NavMeshAgent> ();

	}
	
	// Update is called once per frame
	void Update () {
		
		agent.SetDestination (player.position);

	}

	void OnTriggerEnter(Collider collider)
	{
		if (collider.gameObject.tag == "Fence") {
			
			GetComponent<IMonster>().Death();
			GameController.Instance.canonHealth -= GameController.Instance.damage; 

		}
	}
}
