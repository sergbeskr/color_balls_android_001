using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public class ShootController : MonoBehaviour {

	[SerializeField]
	private Transform emitter;

	[SerializeField]
	private BulletsPool pool;

	[SerializeField]
	private ParticleSystem explosion;

	private Vector3 mousePosition;
	private Vector3 directionRay;
	private Vector3 position;
	private float distance;
	private float forceSpeed = 50;
	private float m_height = 15;

	IBulletsElement element;

	private bool allowfire = true;

	void Start()
	{
	}

	public void FixedUpdate()
	{
		if (allowfire) {
			if (!UIController.isPause) {
				if (Input.GetMouseButtonDown (0) && GameController.playerAlive && !EventSystem.current.IsPointerOverGameObject ()) {
					ActivateBall ();

					AudioManager.PlaySound ("boom1");

					//SergBeskr code

					RaycastHit hit;
					Ray ray = Camera.main.ScreenPointToRay (Input.mousePosition);
					if (Physics.Raycast (ray, out hit, Mathf.Infinity)) {
						position = hit.point;
						directionRay = emitter.TransformDirection (position - emitter.position);  
						distance = Vector3.Distance (position, emitter.position);
						//forceSpeed = Mathf.Sqrt ((distance * 9.8f) / (distance /  m_height));
						forceSpeed = Mathf.Sqrt (9.8f * m_height);
						//Debug.Log("___"+distance/ m_height);
						forceSpeed = forceSpeed * 2.33f;
						element.AddForce (directionRay, forceSpeed, m_height);
						//Debug.Log ("___" + distance + "___" + m_height + "___" + forceSpeed + "___" + directionRay);

					//

						StartCoroutine (AllowFire());
					}
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

	private IEnumerator AllowFire()
	{
		allowfire = false;
		yield return new WaitForSeconds (1f);

		allowfire = true;
	}
}
