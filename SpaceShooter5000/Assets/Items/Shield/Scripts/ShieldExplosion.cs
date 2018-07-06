using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldExplosion : MonoBehaviour {
	public float _explosionSpeed;
	private Vector3 _maxSize;

	void Start () {
		_maxSize = transform.localScale;
		transform.localScale = Vector3.zero;
	}
	
	// Update is called once per frame
	void Update () {
		transform.localScale = Vector3.MoveTowards(transform.localScale, _maxSize, Time.deltaTime * _explosionSpeed);

		if (Mathf.Approximately(transform.localScale.magnitude, _maxSize.magnitude))
		{
			Destroy(gameObject);
		}
	}

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Enemy")
		{
			other.GetComponent<BaseEnemy>().Die();
		}
	}
}
