using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickupItems : MonoBehaviour {
	[SerializeField] private GameObject _shieldPrefab;

	private void OnTriggerEnter(Collider other) {
		if (other.tag == "Shield")
		{
			GameObject go = Instantiate(_shieldPrefab, transform.position, transform.rotation) as GameObject;
			go.transform.parent = transform;
			Destroy(other.gameObject);	
		}
	}
}
