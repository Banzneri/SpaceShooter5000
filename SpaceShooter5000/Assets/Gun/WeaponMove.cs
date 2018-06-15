using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMove : MonoBehaviour {
	[SerializeField] private LayerMask _groundLayer;
	private Camera cam;
	// Use this for initialization
	void Start () {
		cam = Camera.main;
	}
	
	// Update is called once per frame
	void Update () {
		Vector3 forward = transform.forward;
		// angle between mouse and weapon position in screen coordinates
		float angle = Vector3.Angle(Input.mousePosition, cam.WorldToScreenPoint(transform.position));
		Debug.Log(angle);
		RaycastHit hit;
		Ray ray = cam.ScreenPointToRay(Input.mousePosition);

		if (Physics.Raycast(ray, out hit, 1000f, _groundLayer))
		{
			Vector3 lookAtPos = hit.point;
			lookAtPos.y = transform.position.y;
			Quaternion rot = Quaternion.LookRotation(lookAtPos - transform.position, Vector3.up);
			transform.rotation = rot;

		}


	}
}
