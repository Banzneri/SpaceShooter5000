using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyAttack : MonoBehaviour {
	[SerializeField] private GameObject _enemyBulletPrefab;
	[SerializeField] private float _attackDistance = 7f;
	[SerializeField] private float _attackRate = 0.2f;

	private float _attackCounter = 0f;

	private GameObject _player;
	// Use this for initialization
	void Start () {
		_player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		if (Vector3.Distance(transform.position, _player.transform.position) < _attackDistance)
		{
			_attackCounter += Time.deltaTime;
			if (_attackCounter > _attackRate)
			{
				Instantiate(_enemyBulletPrefab, transform.position, transform.rotation);
				_attackCounter = 0f;	
			}
		}
	}
}
