using UnityEngine;
using System.Collections;

public class BulletsElement : MonoBehaviour, IBulletsElement {

	private IBulletsPool _pool;
	private Rigidbody rb;
	private Transform sphere;

	[SerializeField]
	private float forceExp = 500f;
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

	public void AddForce(Vector3 direction, float speed)
	{
		rb.AddForce(direction.x * speed, 35f * speed, direction.z * speed);
	}

	void Explosion()
	{
		Rigidbody rbExp;
		rb.Sleep ();
		explosion.Play();

		foreach (Collider col in Physics.OverlapSphere(transform.position, radiusExp, 1<<8)) {
			rbExp = col.GetComponent<Rigidbody> ();

			if (rbExp != null) {
				//rbExp.AddForce ();
				Debug.Log ("Booom");

				if (OnBang != null) {
					OnBang (col, colorBall);
				}

				//Destroy (col.gameObject); /////////////////////////////////////////////////////////////////////////////
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
}
