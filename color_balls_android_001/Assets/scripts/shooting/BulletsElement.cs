using UnityEngine;
using System.Collections;

public class BulletsElement : MonoBehaviour, IBulletsElement {

	private IBulletsPool _pool;
	private Rigidbody rb;
	private Transform sphere;

	[SerializeField]
	private float radiusExp = 10f;

	private ParticleSystem explosion;

	public Color colorBall { get; set; }

	public delegate void Bang (Collider col, Color color);
	//
	public static event Bang OnBang;

	// Use this for initialization
	void Awake () {
		rb = GetComponent<Rigidbody>();

		sphere = transform.FindChild ("Sphere");
		explosion = transform.FindChild ("ExplosionParticles").GetComponent<ParticleSystem> ();
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

	public void AddForce(Vector3 direction, float speed, float thirtyFive)
	{
		rb.AddForce(direction.x * speed, thirtyFive * speed, direction.z * speed);
	}

	void Explosion()
	{
		rb.Sleep ();
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
