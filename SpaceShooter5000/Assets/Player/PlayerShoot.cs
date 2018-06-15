using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
	[SerializeField] private GameObject _bulletPrefab;
	[SerializeField] private GameObject _threeShotPrefab;
	[SerializeField] private GameObject _gunEnd;
	[SerializeField] private ParticleSystem _shootParticles;

	private WeaponType _currentWeapon = WeaponType.ThreeShot;
	private bool _shooting = false;

	public WeaponType CurrentWeapon
	{
		get { return _currentWeapon; }
		set { _currentWeapon = value; }
	}

	public enum WeaponType
	{
		Regular,
		ThreeShot,
		BombGun
	}
	
	void Start () {
		
	}
	
	void Update () {
		if (Input.GetMouseButton(0))
		{	
			_currentWeapon = WeaponType.Regular;
			Shoot();
		}
		else if (Input.GetMouseButton(1))
		{
			_currentWeapon = WeaponType.ThreeShot;
			Shoot();
		}
		else
		{
			_shooting = false;
		}
		HandleParticles();
	}

	private void Shoot()
	{
		_shooting = true;
		GameObject go = null;
		Bullet[] bullets = null;

		switch (_currentWeapon)
		{
			case WeaponType.Regular:
				go = Instantiate(_bulletPrefab, _gunEnd.transform.position, _gunEnd.transform.rotation);
				bullets = go.GetComponents<Bullet>();
				break;
			case WeaponType.BombGun:
				break;
			case WeaponType.ThreeShot:
				go = Instantiate(_threeShotPrefab, _gunEnd.transform.position, _gunEnd.transform.rotation);
				bullets = go.GetComponentsInChildren<Bullet>();
				break;
		}

		
	}

	private void HandleParticles()
	{
		if (_shooting && !_shootParticles.isPlaying)
		{
			_shootParticles.Play();
		}
		else if (!_shooting && _shootParticles.isPlaying)
		{
			_shootParticles.Stop();
		}
	}
}
