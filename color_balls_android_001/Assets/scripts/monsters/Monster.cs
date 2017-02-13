using UnityEngine;
using System.Collections;

public class Monster : MonoBehaviour, IMonster {

	public float monsterHealth{ get; set;}
	public Color monsterColor{ get; set;}

	public delegate void Kill();
	public static event Kill OnKill;

	public void Awake()
	{
		BulletsElement.OnBang += Hit;
		monsterHealth = GameController.maxMonsterHealth;
	}

	public void Death ()
	{
		BulletsElement.OnBang -= Hit;
		GameController.deadMonsters++;
		gameObject.SetActive(false);
	}

	public void Hit(Collider c, Color ballColor)
	{
		if (c.transform == this.transform) {
			if (ballColor == monsterColor) {
				if (OnKill != null)
					OnKill ();
				Death ();
			} else {
				monsterHealth -= 15;
			}
		}

		if (monsterHealth <= 0) {
			
			Death ();
		}
	}

	public void SetColor(Color color)
	{
		Renderer rend = GetComponent<Renderer> ();
		rend.material.color = color;
		monsterColor = color;
	}

	void OnDestroy()
	{
		OnKill = null;
	}
}
