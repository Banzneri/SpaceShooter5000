using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTakeDamage : MonoBehaviour {
	[SerializeField] private float _life;
	[SerializeField] private GameObject _topPart;
	
	void Start () {
		
	}
	
	void Update () {
		
	}

	private void OnTriggerEnter(Collider other) {
		Debug.Log("Collision");
		if (other.tag == "EnemyBullet")
		{
			StartCoroutine(OnDamage());
			Debug.Log("HitBullet");
			_life -= other.gameObject.GetComponent<Bullet>().Damage;
			Destroy(other.gameObject);
			if (_life < 0)
			{
				Destroy(this.gameObject);
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
