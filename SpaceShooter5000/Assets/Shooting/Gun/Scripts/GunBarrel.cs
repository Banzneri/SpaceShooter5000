using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunBarrel : MonoBehaviour {

	// the muzzle of the gun, i.e. the location where the bullet is spawned from
	[SerializeField] private Transform _muzzle;
	[SerializeField] private Color _shootColor;

	private Color _originalColor;

	private void Start()
	{
		_originalColor = GetComponent<Renderer>().material.color;
	}

	public Transform Muzzle
	{
		get { return _muzzle; }
	}

	public void SetColor(bool shooting)
	{
		GetComponent<Renderer>().material.color = shooting ? _shootColor : _originalColor;
	}
}
