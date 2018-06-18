using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldActive : MonoBehaviour {
	[SerializeField] private float _shieldHealth = 100;
	
	private Material _material;
	private Color _originalColor;

	void Start () {
		_material = GetComponent<Renderer>().material;
		_originalColor = _material.color;
	}
	
	// Update is called once per frame
	void Update () {
		Color lerpedColor = Color.Lerp(_originalColor, Color.red, Mathf.PingPong(Time.time * 10, 1));
		_material.color = lerpedColor;
	}
}
