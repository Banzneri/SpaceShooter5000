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
		if (other.tag == "Item")
		{
			other.GetComponent<IItem>().Use();
		}
	}
}
