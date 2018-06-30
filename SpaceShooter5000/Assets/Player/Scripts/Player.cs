using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private PlayerMove _move;
	[SerializeField] private PlayerTakeDamage _damage;
	[SerializeField] private PlayerPickupItems _pickUp;
	[SerializeField] private PlayerShoot _shoot;

	public int Lives
	{
		get { return _damage._lives; }
	}

	public int MaxLives
	{
		get { return _damage._maxLives; }
	}

	public bool Shielded
	{
		get { return _damage._shielded; }
		set { _damage._shielded = value; }
	}

	public ShieldActive CurrentShield
	{
		get { return _damage.CurrentShield; }
		set { _damage.CurrentShield = value; }
	}

	public float Speed
	{ 
		get { return _move.Speed; }
		set { _move.Speed = value; }
	}

	public Weapon DefaultWeapon
	{
		get { return _shoot.DefaultWeapon; }
	}

	public Weapon ExtraWeapon
	{
		get { return _shoot.ExtraWeapon; }
		set { _shoot.ExtraWeapon = value; }
	}
}
