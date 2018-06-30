using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour {
	[SerializeField] private GunBarrel[] _gunBarrels;
	[SerializeField] private GameObject _bulletPrefab;
	[SerializeField] private float _fireRate = 0.2f;
	[SerializeField] private AudioClip _shootSound;
	[SerializeField] private ParticleSystem[] _shootParticles;

	[HideInInspector] public bool shooting = false;

	public GunBarrel[] Barrels
	{
		get { return _gunBarrels; }
	}

	public float FireRate
	{
		get { return _fireRate; }
		set { _fireRate = value; }
	}

	public ParticleSystem[] Particles
	{
		get { return _shootParticles; }
	}

	public AudioClip Audio
	{
		get { return _shootSound; }
	}

	public void Shoot ()
	{
		foreach (var barrel in _gunBarrels)
		{
			Instantiate(_bulletPrefab, barrel.Muzzle.transform.position, barrel.Muzzle.transform.rotation);
		}
	}
}
