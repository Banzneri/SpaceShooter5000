using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour {
	[SerializeField] private float _damage;
	[SerializeField] private float _speed;
	[SerializeField] private float _aliveTime;

	private Vector3 _direction;
	
	void Update () {
		transform.position += _speed * Time.deltaTime * transform.forward;
	}

	public void Init(Vector3 direction)
	{
		_direction = direction;
	}
}
