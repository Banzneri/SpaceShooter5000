using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldActive : MonoBehaviour {
	[SerializeField] private float _shieldHealth = 100;
	
	private Transform _barPanel;
	private Material _material;
	private Color _originalColor;
	private Player _player;

	void Start () {
		_material = GetComponent<Renderer>().material;
		_originalColor = _material.color;
		_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
		_barPanel = GameObject.FindGameObjectWithTag("BarPanel").transform;
		_player.Shielded = true;
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "EnemyBullet")
		{
			Destroy(other.gameObject);
			DestroyShield();
		}
	}
	
	public void DestroyShield()
	{
		_player.Shielded = false;
		Destroy(gameObject);
	}
}
