using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour, IMonster {

	public float monsterHealth{ get; set;}
	public Color monsterColor{ get; set;}

	public void Awake()
	{
		BulletsElement.OnBang += Hit;
		monsterHealth = GameController.maxMonsterHealth;
	}

	void Death ()
	{
		Destroy (gameObject);
		Debug.Log("Death");
	}

	public void Hit(Collider c, Color ballColor)
	{
		if (c.transform == this.transform) {
			if (ballColor == monsterColor) {
				monsterHealth = 0;
			} else {
				monsterHealth -= 15;
				Debug.Log ("health " + monsterHealth);
			}
		}

		if (monsterHealth <= 0) {
			BulletsElement.OnBang -= Hit;
			Death ();
		}
	}

	public void SetColor(Color color)
	{
		Renderer rend = GetComponent<Renderer> ();
		rend.material.color = color;
		monsterColor = color;
	}

}
