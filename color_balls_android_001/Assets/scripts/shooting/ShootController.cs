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
	private float thirtyFive = 35;
	private float sergAngle;

	IBulletsElement element;


	public void Update()
	{
		if (!UIController.isPause) {
			if (Input.GetMouseButtonDown (0) && GameController.playerAlive && !EventSystem.current.IsPointerOverGameObject ()) {
				ActivateBall ();

				AudioManager.Instance.PlaySoundInternal ("boom1", true);

				RaycastHit hit;
				Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
				if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
					position = hit.point;
					directionRay = emitter.TransformDirection (position - emitter.position);  
					distance = Vector3.Distance(position, emitter.position);
					sergAngle = Mathf.Atan(thirtyFive / Mathf.Sqrt(directionRay.x * directionRay.x + directionRay.z * directionRay.z));
					Debug.Log("1010010101010010101 "+sergAngle);
					forceSpeed = Mathf.Sqrt((distance * 9.8f) / Mathf.Sin(2*sergAngle));
					//forceSpeed = Mathf.Sqrt (9.8f * thirtyFive);
					element.AddForce (directionRay, forceSpeed, thirtyFive);
					Debug.Log("___"+distance+"___"+thirtyFive+"___"+forceSpeed+"___"+directionRay);
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
