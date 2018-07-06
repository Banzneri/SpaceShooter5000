using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	public GunBarrel[] _gunBarrels;
	public GameObject _bulletPrefab;
	public float _fireRate = 0.2f;
	public AudioClip _shootSound;
	public ParticleSystem[] _shootParticles;

	[HideInInspector] public bool shooting = false;
	[HideInInspector] public float fireCounter = 0;

	private Vector3 _maxScale;

	public void Shoot ()
	{
		foreach (var barrel in _gunBarrels)
		{
			Instantiate(_bulletPrefab, barrel._muzzle.transform.position, barrel._muzzle.transform.rotation);
		}
	}

	private void Start() {
		_maxScale = transform.localScale;
		transform.localScale = Vector3.zero;
	}

	private void Update() {
		transform.localScale = Vector3.MoveTowards(transform.localScale, _maxScale, 3 * Time.deltaTime);
	}
}
