using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
	public Weapon _currenDefaultWeapon;
	public Weapon _currentExtraWeapon;

	private bool _shooting = false;
	private AudioSource _audio;
	
	void Start () {
		_audio = GetComponent<AudioSource>();	
	}
	
	void Update () {
		HandleInput();
		HandleShooting();
	}

	private void HandleInput()
	{
		if (PlayerInput.DefaultGunDown())
		{	
			StartShooting(_currenDefaultWeapon);
		}
		else if (PlayerInput.DefaultGunUp())
		{
			StopShooting(_currenDefaultWeapon);
		}
		if (PlayerInput.ExtraGunDown())
		{
			StartShooting(_currentExtraWeapon);
		}
		else if (PlayerInput.ExtraGunUp())
		{
			StopShooting(_currentExtraWeapon);
		}
	}

	public void HandleShooting()
	{
		if (_currenDefaultWeapon.shooting)
		{
			FireGunAutomatic(_currenDefaultWeapon);
		}
		if (_currentExtraWeapon.shooting)
		{
			FireGunAutomatic(_currentExtraWeapon);
		}
	}

	public void FireGunAutomatic(Weapon gun)
	{
		gun.fireCounter += Time.deltaTime;
		if (gun.fireCounter > gun._fireRate)
		{
			gun.Shoot();
			gun.fireCounter = 0;
		}
	}

	private void StartShooting(Weapon gun)
	{
		gun.shooting = true;
		foreach (var particle in gun._shootParticles) particle.Play();
		foreach (var barrel in gun._gunBarrels) barrel.SetColor(true);
		gun.Shoot();
	}

	private void StopShooting(Weapon gun)
	{
		gun.shooting = false;
		gun.fireCounter = 0;
		foreach (var particle in gun._shootParticles) particle.Stop();
		foreach (var barrel in gun._gunBarrels) barrel.SetColor(false);
	}
}
