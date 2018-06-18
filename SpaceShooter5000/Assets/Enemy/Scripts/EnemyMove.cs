using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
	[SerializeField] private GameObject _player;
	[SerializeField] private float _stopDistance;
	// Use this for initialization
	void Start () {
		_player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Quaternion rot = Quaternion.LookRotation(_player.transform.position - transform.position, Vector3.up);
		transform.rotation = rot;
		if (Vector3.Distance(transform.position, _player.transform.position) < _stopDistance)
		{
			return;
		}
		Vector3 newPos = Vector3.MoveTowards(transform.position, _player.transform.position, 0.05f);
		transform.position = newPos;
	}
}
