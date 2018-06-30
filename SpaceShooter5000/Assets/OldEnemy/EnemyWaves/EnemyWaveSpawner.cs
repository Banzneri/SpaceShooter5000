using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWaveSpawner : MonoBehaviour {
	[SerializeField] private Transform[] _spawnWall;
	[SerializeField] private Transform _flyingPlane;
	[SerializeField] private GameObject _enemyWavePrefab;
	[SerializeField] private float _spawnRate;

	private float _spawnTimer = 0;
	
	void Start () {
		
	}
	
	void Update () {
		_spawnTimer += Time.deltaTime;
		if (_spawnTimer > _spawnRate)
		{
			int randIndex = Random.Range(0, _spawnWall.Length);
			Vector3 spawnPos = _spawnWall[randIndex].transform.position;
			spawnPos.y = _flyingPlane.transform.position.y;
			Instantiate(_enemyWavePrefab, spawnPos, _spawnWall[randIndex].transform.rotation);
			_spawnTimer = 0;	
		}
	}
}
