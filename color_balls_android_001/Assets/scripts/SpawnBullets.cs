using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;

public class SpawnBullets : MonoBehaviour {

	private float forceSpeed = 50;
	public GameObject bulletPref;
	private GameObject prefInst;
	private Vector3 mousePosition;
	private Vector3 directionRay;
	private Vector3 position;
	//private Vector3 direction;

	void Start() {
		
	}

	void Update() {
		if (GameController.alive && 
			Input.GetMouseButtonDown (0) && 
			!EventSystem.current.IsPointerOverGameObject()) {

			Shoot();
		}
	}

	void Shoot(){
		//mousePosition = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, 1));
		RaycastHit hit;
		Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
		if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
			position = hit.point;
			//prefInst = Instantiate (bulletPref, position, Quaternion.identity) as GameObject;
			directionRay = transform.TransformDirection (position - transform.position);    
			prefInst = Instantiate (bulletPref, transform.position, Quaternion.identity) as GameObject;
			Rigidbody rb = prefInst.GetComponent<Rigidbody> ();
			//rb.AddForce (directionRay * forceSpeed);
			rb.AddForce (directionRay.x * forceSpeed, 10 * forceSpeed, directionRay.z * forceSpeed);
		}         
	}
		
/*	void ShootOld(){
		//mousePosition = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));
		mousePosition = Camera.main.ScreenToWorldPoint (new Vector3(Input.mousePosition.x, Input.mousePosition.y, Camera.main.transform.position.y));

		directionRay = transform.TransformDirection (mousePosition);
		prefInst = Instantiate (bulletPref, transform.position, Quaternion.identity) as GameObject;
		Renderer rend = prefInst.GetComponent<Renderer> ();
		//rend.material.color = 
		Rigidbody rb = prefInst.GetComponent<Rigidbody> ();
		rb.AddForce (directionRay * forceSpeed);
		//rb.AddForce ((mousePosition.x-transform.position.x) * forceSpeed, (mousePosition.y-transform.position.y) * forceSpeed, (mousePosition.z-transform.position.z) * forceSpeed);
		rb.AddForce (mousePosition.x * forceSpeed, mousePosition.y * forceSpeed, mousePosition.z * forceSpeed);

		Debug.Log(mousePosition);
		Debug.Log(rb.transform.position);
	}*/
}
