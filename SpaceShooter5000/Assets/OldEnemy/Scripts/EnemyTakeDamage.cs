﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyTakeDamage : MonoBehaviour {
	[SerializeField] private float _life;
	[SerializeField] private GameObject _explosionParticlePrefab;

	private EnemySounds _sound;
	private Renderer _renderer;
	private Color _originalColor;
	private bool _alive = true;

	private void Start() {
		_renderer = GetComponent<Renderer>();
		_originalColor = _renderer.material.color;
		_sound = GameObject.FindGameObjectWithTag("Sounds").GetComponent<EnemySounds>();
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Bullet")
		{
			_life -= other.gameObject.GetComponent<Bullet>().Damage;
			Destroy(other.gameObject);
			if (_life < 0) Die();
			StartCoroutine(Blink());
		}
	}

	private IEnumerator Blink()
	{
		_renderer.material.color = Color.red;
		yield return new WaitForSeconds(0.05f);
		_renderer.material.color = _originalColor;
	}

	private void Die()
	{
		_sound.PlayDestructionSound();
		Instantiate(_explosionParticlePrefab, transform.position, Quaternion.identity);
		Destroy(this.gameObject);
	}
}
