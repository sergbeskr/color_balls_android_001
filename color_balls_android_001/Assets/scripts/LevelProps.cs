using UnityEngine;
using System.Collections;
using System;

[Serializable]
public class LevelProps {

	public int level;
	public int canonHealth;
	public int maxMonsterHealth;
	public int damage;
	public int spawnMonstersRadius;
	public int startNumberOfMonsters;
	public int numberOfSpawners;
	public float timeOfSpawn;
	[NonSerialized]
	public static int levelCurr = 1;
	[NonSerialized]
	public static int awardForLevel;
}
