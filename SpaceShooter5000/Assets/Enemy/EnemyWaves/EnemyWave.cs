using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyWave : MonoBehaviour {
	[SerializeField] private GameObject _enemyPrefab;
	[SerializeField] private EnemyWaveType _waveType;
	[SerializeField] private float _spawnRate;
	[SerializeField] private float _spawnDuration;

	private float _spawnTimer = 0f;

	public enum EnemyWaveType
	{
		SingleStraight,
		ThreeStraight,
		FullSide
	}

	void Start () {
		switch (_waveType)
		{
			case EnemyWaveType.SingleStraight:
				StartCoroutine(Spawn(_enemyPrefab));
				break;
			case EnemyWaveType.ThreeStraight:
				StartCoroutine(SpawnThreeStraight(_enemyPrefab));
				break;
		}
	}
	
	void Update () {
		_spawnTimer += Time.deltaTime;
	}

	private IEnumerator Spawn(GameObject enemy)
	{
		while (_spawnTimer < _spawnDuration)
		{
			yield return new WaitForSeconds(_spawnRate);
			Instantiate(enemy, transform.position, Quaternion.identity);
		}
		Destroy(gameObject);
	}

	private IEnumerator SpawnThreeStraight(GameObject enemy)
	{
		while (_spawnTimer < _spawnDuration)
		{
			Vector3 rightPos = transform.position + transform.right * 2;
			Vector3 leftPos = transform.position - transform.right * 2;
			yield return new WaitForSeconds(_spawnRate);
			Instantiate(enemy, transform.position, Quaternion.identity);
			Instantiate(enemy, rightPos, Quaternion.identity);
			Instantiate(enemy, leftPos, Quaternion.identity);
		}
		Destroy(gameObject);
	}
}
