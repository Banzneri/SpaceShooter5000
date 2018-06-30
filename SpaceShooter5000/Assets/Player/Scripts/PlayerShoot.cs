using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour {
	[SerializeField] private Weapon _currenDefaultWeapon;
	[SerializeField] private Weapon _currentExtraWeapon;

	private bool _shooting = false;
	private AudioSource _audio;

	public Weapon DefaultWeapon
	{
		get { return _currenDefaultWeapon; }
		set { _currenDefaultWeapon = value; }
	}

	public Weapon ExtraWeapon
	{
		get { return _currentExtraWeapon; }
		set { _currentExtraWeapon = value; }
	}

	public bool Shooting
	{
		get { return _shooting; }
	}
	
	void Start () {
		_audio = GetComponent<AudioSource>();	
	}
	
	void Update () {
		HandleShooting();
	}

	private void HandleShooting()
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

	private IEnumerator Shoot(Weapon gun)
	{
		while (gun.shooting)
		{
			yield return new WaitForSeconds(gun.FireRate);
			gun.Shoot();
		}		
	}
	private void StartShooting(Weapon gun)
	{
		gun.shooting = true;
		foreach (var particle in gun.Particles) particle.Play();
		foreach (var barrel in gun.Barrels) barrel.SetColor(true);
		StartCoroutine(Shoot(gun));
	}

	private void StopShooting(Weapon gun)
	{
		gun.shooting = false;
		foreach (var particle in gun.Particles) particle.Stop();
		foreach (var barrel in gun.Barrels) barrel.SetColor(false);
	}
}
