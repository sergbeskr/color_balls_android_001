using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class ShootController : MonoBehaviour {

	[SerializeField]
	private Transform emitter;

	[SerializeField]
	private BulletsPool pool;

	private Vector3 mousePosition;
	private Vector3 directionRay;
	private Vector3 position;
	private float distance;
	private float forceSpeed = 50;

	IBulletsElement element;


	public void Update()
	{
		if (!UIController.isPause) {
			if (Input.GetMouseButtonDown (0) && GameController.playerAlive && !EventSystem.current.IsPointerOverGameObject ()) {
				ActivateBall ();

				AudioManager.PlaySound ("boom1");

				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					position = hit.point;
					directionRay = emitter.TransformDirection (position - emitter.position);  
					distance = Vector3.Distance (position, emitter.position);
					forceSpeed = Mathf.Sqrt ((distance * 9.8f) / (distance / 35f));

					element.AddForce (directionRay, forceSpeed);
				}
			}
		}
	}

	void ActivateBall()
	{
		element = pool.GetElement();                
		element.SetPosition(emitter.position);
		element.Activate();
	}
			
}
