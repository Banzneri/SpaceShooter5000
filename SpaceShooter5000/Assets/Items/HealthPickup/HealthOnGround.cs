using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthOnGround : MonoBehaviour {
	[SerializeField] private float _healAmount;
	private PlayerTakeDamage _playerDamage;
	

	private void Start() {
		_playerDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTakeDamage>();
	}

	public void Heal()
	{
		_playerDamage.Health += _healAmount;
		Debug.Log(_playerDamage.GetComponent<PlayerTakeDamage>().Health);
		Destroy(gameObject);
	}
}
