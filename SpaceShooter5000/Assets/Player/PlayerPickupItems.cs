using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupItems : MonoBehaviour {
	[SerializeField] private GameObject _shieldPrefab;
	
	private PlayerTakeDamage _playerDamage;

	private void Start() {
		_playerDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTakeDamage>();
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Shield")
		{
			Destroy(other.gameObject);
			if (_playerDamage.CurrentShield != null)
			{
				_playerDamage.CurrentShield.Health = _playerDamage.CurrentShield.MaxHealth;
				return;
			}
			GameObject go = Instantiate(_shieldPrefab, transform.position, transform.rotation) as GameObject;
			go.transform.parent = transform;
		}
		else if (other.tag == "HealthPickup")
		{
			other.GetComponent<HealthOnGround>().Heal();
		}
	}
}
