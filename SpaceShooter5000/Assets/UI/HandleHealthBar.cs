using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HandleHealthBar : MonoBehaviour {
	private Slider _healthBar;
	private PlayerTakeDamage _playerDamage;
	private float _maxHealth;

	void Start () {
		_healthBar = GetComponent<Slider>();
		_playerDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTakeDamage>();
		_maxHealth = _playerDamage.Health;
	}
	
	void Update () {
		_healthBar.value = _playerDamage.Health / _maxHealth;
	}
}
