using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class LevelsProps {
	
	[Serializable]
	public struct Level{
		
		public int level;
		public int damage;
		public int canonHealth;
		public int maxMonsterHealth;
		public int spawnMonstersRadius;
		public int startNumberOfMonsters;
		
	}
	
	public Level[] levels;
	
}
