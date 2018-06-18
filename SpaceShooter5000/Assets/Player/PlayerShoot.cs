using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
	[SerializeField] private GameObject _bulletPrefab;
	[SerializeField] private GameObject _threeShotPrefab;
	[SerializeField] private GameObject _gunEnd;
	[SerializeField] private ParticleSystem _shootParticles;
	[SerializeField] private float _fireRate;
	[SerializeField] private AudioClip _shootSound;
	[SerializeField] private GameObject _gunShaft;

	private WeaponType _currentWeapon = WeaponType.ThreeShot;
	private bool _shooting = false;
	private AudioSource _audio;

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
		_audio = GetComponent<AudioSource>();	
	}
	
	void Update () {
		HandleShooting();
		HandleParticles();
	}

	private void HandleShooting()
	{
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
			_gunShaft.GetComponent<Renderer>().material.color = Color.white;
			_shooting = false;
		}
	}

	private void Shoot()
	{
		_gunShaft.GetComponent<Renderer>().material.color = Color.red;
		_audio.PlayOneShot(_shootSound);
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

	public void HandleShaftColor()
	{
		if (_shooting)
		{
			_gunShaft.GetComponent<Renderer>().material.color = Color.red;
		}
		else
		{
			_gunShaft.GetComponent<Renderer>().material.color = Color.white;
		}
	}
}
