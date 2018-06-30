using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponOnGround : MonoBehaviour, IItem {
	[SerializeField] private Weapon _weaponPrefab;
	
	private Player _player;

    void Start () {
		_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();	
	}

	public void Use()
    {
        _player.ExtraWeapon = Instantiate(_weaponPrefab, _player.transform.position, transform.rotation) as Weapon;
    }
}
