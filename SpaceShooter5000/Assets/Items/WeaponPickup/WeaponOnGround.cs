using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponOnGround : MonoBehaviour, IItem {
	[SerializeField] private Weapon[] _weaponPrefabs;
	
	private Player _player;

    void Start () {
		_player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();	
	}

	public void Use()
    {
		Destroy(_player.ExtraWeapon.gameObject);
		int randomIndex = Random.Range(0, _weaponPrefabs.Length);
        _player.ExtraWeapon = Instantiate(_weaponPrefabs[randomIndex], _player.transform.position, _player.transform.rotation, _player.transform) as Weapon;
		Destroy(gameObject);
    }
}
