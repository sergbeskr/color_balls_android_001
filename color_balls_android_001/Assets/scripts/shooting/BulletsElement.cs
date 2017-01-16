using UnityEngine;
using System.Collections;

public class BulletsElement : MonoBehaviour, IBulletsElement {

	private IBulletsPool _pool;
	private Rigidbody rb;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody>();
	}

	public void Dispose()
	{
		gameObject.SetActive(false);

		if (_pool != null)
		{
			Debug.Log("putItem");
			_pool.PutItem(this);
		}
	}
		
	public void SetPool(IBulletsPool pool)
	{
		_pool = pool;
	}

	public void Activate()
	{
		gameObject.SetActive(true);
		StartCoroutine(LifeTimeCoroutine());
	}

	private IEnumerator LifeTimeCoroutine()
	{
		yield return new WaitForSeconds(2f);            

		this.Dispose();
	}

	public void SetPosition(Vector3 position)
	{
		transform.position = position;
	}

	public void AddForce(Vector3 force, float speed)
	{
		rb.AddForce(force.x * speed, 35f * speed, force.z * speed);
	}
}
