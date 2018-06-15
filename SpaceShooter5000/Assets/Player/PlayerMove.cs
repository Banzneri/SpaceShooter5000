using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	[SerializeField] private float _moveSpeed = 10f;

	private Vector3 _velocity = Vector3.zero;
	private Rigidbody _rb;

	void Start () {
		_rb = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update () {
		float xSpeed = Input.GetAxis("Horizontal") * _moveSpeed;
		float ySpeed = Input.GetAxis("Vertical") * _moveSpeed;

		_rb.velocity = new Vector3(xSpeed, 0, ySpeed);
	}
}
