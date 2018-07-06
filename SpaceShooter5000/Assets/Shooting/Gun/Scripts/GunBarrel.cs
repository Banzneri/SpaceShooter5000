using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBarrel : MonoBehaviour {

	// the muzzle of the gun, i.e. the location where the bullet is spawned from
	public Transform _muzzle;
	[SerializeField] private Color _shootColor;

	private Color _originalColor;

	private void Start()
	{
		_originalColor = GetComponent<Renderer>().material.color;
	}

	public void SetColor(bool shooting)
	{
		GetComponent<Renderer>().material.color = shooting ? _shootColor : _originalColor;
	}

	private void OnDrawGizmos() {
		Gizmos.color = Color.red;
		Gizmos.DrawWireSphere(_muzzle.transform.position, 0.14f);
		Gizmos.DrawLine(_muzzle.transform.position, _muzzle.transform.position + 0.5f * _muzzle.transform.forward);
	}
}
