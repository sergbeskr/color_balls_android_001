using UnityEngine;
using System.Collections;

public class BulletsElement : MonoBehaviour, IBulletsElement {

	private IBulletsPool _pool;
	private Rigidbody rb;
	private Renderer[] rend;

	[SerializeField]
	private Transform ball, sphere;
	[SerializeField]
	private ParticleSystem explosion;
	[SerializeField]
	private float radiusExp = 10f;

	public Color colorBall { get; set; }

	public delegate void Bang (Collider col, Color color);
	//
	public static event Bang OnBang;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody>();
		rend = ball.GetComponentsInChildren<Renderer> ();
	}

	public void Dispose()
	{
		gameObject.SetActive(false);

		if (_pool != null)
		{
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
		rb.WakeUp ();

		foreach(Renderer r in rend)
		{
			r.enabled = true;
		}

		StartCoroutine(LifeTimeCoroutine(8f));
	}

	private IEnumerator LifeTimeCoroutine(float sec)
	{
		yield return new WaitForSeconds(sec);            

		this.Dispose();
	}

	public void SetPosition(Vector3 position)
	{
		transform.position = position;
	}

	public void AddForce(Vector3 direction, float speed, float m_height)
	{
		rb.AddForce(direction.x * speed, m_height * speed, direction.z * speed);
	}

	void Explosion()
	{
		rb.Sleep ();

		foreach(Renderer r in rend)
		{
			r.enabled = false;
		}

		explosion.Play();

		foreach (Collider col in Physics.OverlapSphere(transform.position, radiusExp, 1<<8)) {
				if (OnBang != null) {
					OnBang (col, colorBall);
				}
		}
	}

	void OnCollisionEnter(Collision collision)
	{			
		Explosion ();
		StartCoroutine (LifeTimeCoroutine (0.5f));
	}

	public void SetColor(Color m_color)
	{
		Renderer rend = sphere.GetComponent<Renderer> ();
		rend.material.color = m_color;
		colorBall = m_color;
	}

	void OnDestroy()
	{
		OnBang = null;
	}
}
