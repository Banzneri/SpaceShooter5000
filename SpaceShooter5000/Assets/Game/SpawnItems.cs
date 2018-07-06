using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnItems : MonoBehaviour {
	[SerializeField] private GameObject _spawnPlane;
	[SerializeField] private float _spawnRate;
	[SerializeField] private GameObject _shieldPickup;
	[SerializeField] private GameObject _weaponPickup;

	private float _spawnTimer;
	private System.Random rand = new System.Random();
	private float _sizeX;
	private float _sizeZ;

	public enum ItemType
	{
		Shield,
		Weapon
	}

	private void Start() {
		_sizeX = _spawnPlane.transform.localScale.x * 10;
		_sizeZ = _spawnPlane.transform.localScale.z * 10;
	}
	
	void Update () {
		_spawnTimer += Time.deltaTime;
		if (_spawnTimer > _spawnRate)
		{
			Spawn();
		}
	}

	private void Spawn()
	{
		_spawnTimer = 0;
		System.Array array = System.Enum.GetValues(typeof(ItemType));
		ItemType randomType = (ItemType) array.GetValue(rand.Next(array.Length));

		float randX = Random.Range(-_sizeX / 2, _sizeX / 2);
		float randZ = Random.Range(-_sizeZ / 2, _sizeZ / 2);
		Vector3 spawnPos = new Vector3(randX, 0, randZ);
		switch (randomType)
		{
			case ItemType.Shield:
				Instantiate(_shieldPickup, spawnPos, Quaternion.identity);
				break;
			case ItemType.Weapon:
				Instantiate(_weaponPickup, spawnPos, Quaternion.identity);
				break;
		}
	}
}
