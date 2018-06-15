using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DieAfterSeconds : MonoBehaviour {
	[SerializeField] private float _aliveTime;
	
	void Start () {
		StartCoroutine(Die());
	}

	private IEnumerator Die()
	{
		yield return new WaitForSeconds(_aliveTime);
		Destroy(gameObject);
	}
}
