using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {
	public Wave[] waves;
	public Enemy enemy;
	Wave currentWave;
	int currentWaveNumber;
	int enemiesRemaining;
	int enemiesAlive;
	float nextSpawnTime;

	
	void Start()
	{
		NextWave();
	}

	void Update()
	{
		if (enemiesRemaining > 0 && Time.time > nextSpawnTime)
		{
			enemiesRemaining--;
			nextSpawnTime = Time.time + currentWave.timeBetweenSpawns;
			Enemy spawnedEnemy = Instantiate(enemy, Vector3.zero, Quaternion.identity) as Enemy;
			spawnedEnemy.OnDeath += OnEnemyDeath;
		}
	}

	void OnEnemyDeath()
	{
		enemiesAlive--;
		print("Killed");
		if (enemiesAlive == 0)
		{
			NextWave();
		}
	}
	
	void NextWave()
	{
		currentWaveNumber++;
		print(currentWaveNumber);
		if (currentWaveNumber - 1 < waves.Length)
		{
		currentWave = waves[currentWaveNumber - 1];
		enemiesRemaining = currentWave.enemyCount;
		enemiesAlive = enemiesRemaining;
		}
	}
	[System.Serializable]
	public class Wave
	{
		public int enemyCount;
		public float timeBetweenSpawns;
	}
}
