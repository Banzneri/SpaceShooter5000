using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerTakeDamage : MonoBehaviour {
	[SerializeField] private float _life;
	[SerializeField] private GameObject _topPart;
	[SerializeField] private bool _shielded;
	
	private float _maxLife;

	public bool Shielded
	{
		set { _shielded = value; }
	}

	public float Health
	{
		get { return _life; }
		set { _life = Mathf.Clamp(value, 0, _maxLife); }
	}

	void Start () {
		_maxLife = _life;
	}
	
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other) {
		Debug.Log("Collision");
		if (_shielded)
		{
			return;
		}
		if (other.tag == "EnemyBullet")
		{
			StartCoroutine(OnDamage());
			Debug.Log("HitBullet");
			Health -= other.gameObject.GetComponent<Bullet>().Damage;
			Destroy(other.gameObject);
			if (_life <= 0)
			{
				Scene loadedLevel = SceneManager.GetActiveScene ();
         		SceneManager.LoadScene (loadedLevel.buildIndex);
			}
		}
	}

	private IEnumerator OnDamage()
	{
		_topPart.GetComponent<Renderer>().material.color = Color.red;
		yield return new WaitForSeconds(0.1f);
		_topPart.GetComponent<Renderer>().material.color = Color.green;
	}

	
}
