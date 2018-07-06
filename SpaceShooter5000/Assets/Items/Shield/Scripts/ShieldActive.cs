using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldActive : MonoBehaviour {
	[SerializeField] private float _shieldHealth = 100;
	[SerializeField] private GameObject _shieldExplosionPrefab;
	[SerializeField] private float _shieldDestructDelay;
	
	private Material _material;
	private Color _originalColor;
	private Player _player;

	void Start () {
		_material = GetComponent<Renderer>().material;
		_originalColor = _material.color;
		_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		_player.Shielded = true;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "EnemyBullet" || other.tag == "Enemy")
		{
			Destroy(other.gameObject);
			StartCoroutine(DestroyShield());
		}
	}
	
	public IEnumerator DestroyShield()
	{
		Instantiate(_shieldExplosionPrefab, transform.position, Quaternion.identity, _player.transform);
		yield return new WaitForSeconds(_shieldDestructDelay);
		_player.Shielded = false;
		Destroy(gameObject);
	}
}
