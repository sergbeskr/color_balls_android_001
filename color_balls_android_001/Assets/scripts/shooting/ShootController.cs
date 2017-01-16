using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class ShootController : MonoBehaviour {

	[SerializeField]
	private Transform emitter;

	[SerializeField]
	private BulletsPool pool;

	private float dps = -1;

	private Vector3 mousePosition;
	private Vector3 directionRay;
	private Vector3 position;
	private float distance;
	private float forceSpeed = 50;

	public void Update()
	{
		if(Input.GetMouseButtonDown (0) && GameController.alive && !EventSystem.current.IsPointerOverGameObject()){
			if (dps < 0)
			{
				dps = 0.1f;
				IBulletsElement element = pool.GetElement();                
				element.SetPosition(emitter.position);
				element.Activate();

				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
				if (Physics.Raycast(ray, out hit, Mathf.Infinity)) {
					position = hit.point;
					directionRay = transform.TransformDirection (position - emitter.position);  
					distance = Vector3.Distance(position, emitter.position);
					forceSpeed = Mathf.Sqrt ((distance * 9.8f) / (distance / 35f));

					element.AddForce (directionRay, forceSpeed);
				}
			}
			else
			{
				dps -= Time.fixedDeltaTime;
			}

		}
		else
		{
			dps = -1;
		}
	}
			
}
