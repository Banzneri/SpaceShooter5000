using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTakeDamage : MonoBehaviour {
	// the "hat" of the ship
	public GameObject _head;
	public int _maxLives;

	// 
	[HideInInspector] public bool _shielded = false;
	[HideInInspector] public int _lives;
	
	public ShieldActive CurrentShield { get; set; }

	void Start () {
		_lives = _maxLives;
	}

	private void OnTriggerEnter(Collider other) {
		if (_shielded)
		{
			return;
		}
		if (other.tag == "EnemyBullet" || other.tag == "Enemy")
		{
			LoseLife();
		}
	}

	private void LoseLife()
	{
		_lives--;
		if (_lives <= 0)
		{
			Die();
		}
	}

	private void Die()
	{
		Scene loadedLevel = SceneManager.GetActiveScene ();
		SceneManager.LoadScene (loadedLevel.buildIndex);
	}
}
