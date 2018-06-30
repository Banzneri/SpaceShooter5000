using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTakeDamage : MonoBehaviour {
	public GameObject _topPart;
	public int _maxLives;

	[HideInInspector] public bool _shielded = false;
	[HideInInspector] public int _lives;
	
	public ShieldActive CurrentShield { get; set; }

	void Start () {
		_lives = _maxLives;
	}

	private void OnTriggerEnter(Collider other) {
		Debug.Log("Collision");
		if (_shielded)
		{
			return;
		}
		if (other.tag == "EnemyBullet")
		{
			LoseLife();
		}
	}

	private IEnumerator OnDamage()
	{
		_topPart.GetComponent<Renderer>().material.color = Color.red;
		yield return new WaitForSeconds(0.1f);
		_topPart.GetComponent<Renderer>().material.color = Color.green;
	}

	private void LoseLife()
	{
		StartCoroutine(OnDamage());
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
