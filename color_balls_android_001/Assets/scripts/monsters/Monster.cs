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

	public void Death ()
	{
		BulletsElement.OnBang -= Hit;
		GameController.killedMonsters++;
		Destroy (gameObject);
	}

	public void Hit(Collider c, Color ballColor)
	{
		if (c.transform == this.transform) {
			if (ballColor == monsterColor) {
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

}
