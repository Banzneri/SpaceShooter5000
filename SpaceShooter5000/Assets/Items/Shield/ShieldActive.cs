using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldActive : MonoBehaviour {
	[SerializeField] private float _shieldHealth = 100;
	
	private Material _material;
	private Color _originalColor;
	private PlayerTakeDamage _playerDamage;

	void Start () {
		_material = GetComponent<Renderer>().material;
		_originalColor = _material.color;
		_playerDamage = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerTakeDamage>();
		_playerDamage.Shielded = true;
	}
	
	// Update is called once per frame
	void Update () {
		Color lerpedColor = Color.Lerp(_originalColor, Color.red, Mathf.PingPong(Time.time * 10, 1));
		_material.color = lerpedColor;

		if (_shieldHealth <= 0)
		{
			_playerDamage.Shielded = false;
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "EnemyBullet")
		{
			Bullet bullet = other.GetComponent<Bullet>();
			_shieldHealth -= bullet.Damage;
			Destroy(other.gameObject);
		}
	}
}
