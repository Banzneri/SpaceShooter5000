using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnEnemies : MonoBehaviour {
	[SerializeField] private Transform[] _spawnWalls;
	[SerializeField] private float _spawnRate;
	[SerializeField] private GameObject _spawnPlane;
	[SerializeField] private GameObject _enemyPrefab;

	private float _spawnTimer = 0f;
	
	void Update () {
		_spawnTimer += Time.deltaTime;

		if (_spawnTimer > _spawnRate)
		{
			Spawn();
		}
	}

	private void Spawn()
	{
		_spawnTimer = 0;
		int randIndex = Random.Range(0, _spawnWalls.Length);
		Vector3 spawnWallPos = _spawnWalls[randIndex].transform.position;
		spawnWallPos.y = _spawnPlane.transform.position.y;
		Instantiate(_enemyPrefab, spawnWallPos, Quaternion.identity);
	}
}
