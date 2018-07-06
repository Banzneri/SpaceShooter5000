using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {
    [SerializeField] private PlayerMove _move;
	[SerializeField] private PlayerTakeDamage _damage;
	[SerializeField] private PlayerPickupItems _pickUp;
	[SerializeField] private PlayerShoot _shoot;
	[SerializeField] private PlayerScore _score;

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

	public Weapon DefaultWeapon
	{
		get { return _shoot._currenDefaultWeapon; }
	}

	public Weapon ExtraWeapon
	{
		get { return _shoot._currentExtraWeapon; }
		set { _shoot._currentExtraWeapon = value; }
	}

	public GameObject TopPart
	{
		get { return _damage._head; }
	}

	public float Score
	{
		get { return _score.f_Score; }
	}

	public float ScoreMultiplier
	{
		get { return _score.f_Multiplier; }
	}
}
