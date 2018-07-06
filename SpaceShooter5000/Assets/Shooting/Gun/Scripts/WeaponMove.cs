using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WeaponMove : MonoBehaviour {
	[SerializeField] private LayerMask _groundLayer;
	
	private Camera cam;

	void Start () {
		cam = Camera.main;
	}
	
	void Update () {
		Vector3 forward = transform.forward;
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
