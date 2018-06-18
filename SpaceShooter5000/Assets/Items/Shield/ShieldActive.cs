﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldActive : MonoBehaviour {
	[SerializeField] private float _shieldHealth = 100;
	[SerializeField] private ShieldBar _shieldBar;
	
	private Transform _barPanel;
	private Material _material;
	private Color _originalColor;
	private PlayerTakeDamage _playerDamage;
	private float _maxShield;

	public float Health
	{
		get { return _shieldHealth; }
		set { _shieldHealth = value; }
	}

	public float MaxHealth
	{
		get { return _maxShield; }
	}

	void Start () {
		_material = GetComponent<Renderer>().material;
		_originalColor = _material.color;
		_playerDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTakeDamage>();
		_barPanel = GameObject.FindGameObjectWithTag("BarPanel").transform;
		_playerDamage.Shielded = true;
		_playerDamage.CurrentShield = this;
		_shieldBar = Instantiate(_shieldBar, transform.position, Quaternion.identity, _barPanel) as ShieldBar;
		_shieldBar.Init();
		_maxShield = _shieldHealth;
	}
	
	void Update () {
		if (_shieldHealth < _maxShield / 2f)
		{
			Color lerpedColor = Color.Lerp(_originalColor, Color.red, Mathf.PingPong(Time.time * 10, 1));
			_material.color = lerpedColor;	
		}
		_shieldBar.SetBarValue(_shieldHealth / _maxShield);
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "EnemyBullet")
		{
			Bullet bullet = other.GetComponent<Bullet>();
			_shieldHealth -= bullet.Damage;
			Destroy(other.gameObject);
			if (_shieldHealth <= 0)
			{
				_playerDamage.Shielded = false;
				Destroy(_shieldBar.gameObject);
				Destroy(gameObject);
			}
		}
	}
}
