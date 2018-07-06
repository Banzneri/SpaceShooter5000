using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{

	// The speed player moves with
	[SerializeField]
	private float f_MovingSpeed;

	// The area player can move on
	[SerializeField]
	private MovingZone m_MovingZone;


	// Update is called once per frame
	void Update()
	{

		// Take input
		float xSpeed = Input.GetAxis("Horizontal") * f_MovingSpeed * Time.deltaTime;
		float ySpeed = Input.GetAxis("Vertical") * f_MovingSpeed * Time.deltaTime;

		// Move player, and clamp position
		transform.Translate(new Vector3(xSpeed, m_MovingZone.transform.position.y, ySpeed));
		ClampPosition();

	}

	// Clamps player's position to t_ MovingZone
	private void ClampPosition()
	{
		float xClamped = Mathf.Clamp(transform.position.x, m_MovingZone.BottomLeft.position.x, m_MovingZone.TopRight.position.x);
		float yClamped = Mathf.Clamp(transform.position.z, m_MovingZone.BottomLeft.position.z, m_MovingZone.TopRight.position.z);
		transform.position = new Vector3(xClamped, 0, yClamped);
	}

}
