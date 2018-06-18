using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThreeShot : MonoBehaviour {
	[SerializeField] private float _aliveTime = 2f;
	
	void Start () {
		Die();
	}
	
	void Update () {
		
	}

	public IEnumerator Die()
	{
		yield return new WaitForSeconds(_aliveTime);
		Destroy(gameObject);
	}
}
