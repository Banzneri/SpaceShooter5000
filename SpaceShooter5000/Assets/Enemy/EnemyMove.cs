using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMove : MonoBehaviour {
	[SerializeField] private GameObject _player;
	// Use this for initialization
	void Start () {
		_player = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 newPos = Vector3.MoveTowards(transform.position, _player.transform.position, 0.2f);
		transform.position = newPos;
	}
}
