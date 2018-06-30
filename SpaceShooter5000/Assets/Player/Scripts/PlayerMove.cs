using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {
	[SerializeField] private float _moveSpeed = 10f;

	private Rigidbody _rb;

	public float Speed
	{
		get { return _moveSpeed; }
		set { _moveSpeed = value; }
	}

	public Vector3 CurrentVelocity
	{
		get { return _rb.velocity; }
	}

	void Start () {
		_rb = GetComponent<Rigidbody>();
	}
	
	void Update () {
		float xSpeed = PlayerInput.GetAxis().x * _moveSpeed;
		float ySpeed = PlayerInput.GetAxis().y * _moveSpeed;

		_rb.velocity = new Vector3(xSpeed, 0, ySpeed);
	}
}
