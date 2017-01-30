using UnityEngine;
using System;

public interface IMonster {

	float monsterHealth { get; set;}
	Color monsterColor{ get; set;}

	void Hit (Collider c, Color ballColor);
	void Death ();
	void SetColor(Color color);
}
